using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Отвечает за смену сцен с соответствующими эффектами
/// </summary>
public class SceneSystem : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    private SpriteRenderer blackScreenSprite;

    private void Start()
    {
        blackScreenSprite = blackScreen.GetComponent<SpriteRenderer>();
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine("OnChangeScreen", sceneName);
    }

    private IEnumerator OnChangeScreen(string sceneName)
    {
        var color = blackScreenSprite.color;
        while (color.a <= 1)
        {
            color.a += 0.01f;
            blackScreenSprite.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(sceneName);
        yield break;
    }
}
