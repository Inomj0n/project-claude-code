using System.Collections;
using TMPro;
using UnityEngine;
using EventBus;

namespace Dialog
{
    public class DialogSystem : MonoBehaviour, IDialogEvent
    {
        [SerializeField] private GameObject _dialogBox;
        [SerializeField] private GameObject _dialogBoxText;
        [SerializeField] private GameObject _dialogBoxNameText;
        [SerializeField] private GameObject _textBoxCollider;
        [SerializeField] private AudioSource _textAudio;
        [SerializeField] private TextBoxColliderSystem _textBoxColliderSystem;

        private TextMeshProUGUI text;
        private TextMeshProUGUI nameText;

        private Dialogs dialogs;

        private void OnEnable()
        {
            EventBusSystem.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBusSystem.Unsubscribe(this);
        }

        public void Start()
        {
            text = _dialogBoxText.GetComponent<TMPro.TextMeshProUGUI>();
            nameText = _dialogBoxNameText.GetComponent<TMPro.TextMeshProUGUI>();
        }

        public void CreateDialog(Dialogs dialogs)
        {
            _dialogBox.SetActive(true);
            _textBoxCollider.SetActive(true);
            this.dialogs = dialogs;
            ContinueDialog();
        }

        public void ContinueDialog()
        {
            var dialog = dialogs.GetNextDialog();

            if (dialog == null)
            {
                RemoveDialog();
                return;
            }

            nameText.text = dialog.Value.name;
            text.text = string.Empty;
            StartCoroutine("WritingText", dialog.Value.dialog);
        }

        public void RemoveDialog()
        {
            _dialogBox.SetActive(false);
            StopCoroutine("WritingText");

            nameText.text = string.Empty;
            text.text = string.Empty;
            _textBoxCollider.SetActive(false);
        }

        private IEnumerator WritingText(string text)
        {
            int num = 0;
            while (text.Length > num)
            {
                this.text.text += text[num];
                _textAudio.Play();
                num++;
                yield return new WaitForSeconds(0.05f);
            }
            yield break;
        }
    }

}
