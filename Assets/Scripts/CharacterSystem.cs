using Dialog;
using EventBus;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSystem : MonoBehaviour, IPointerDownHandler
{
    private List<Dialogs> AllCharactersDialogs = new();
    private int DialogsNumber = -1;

    public void OnPointerDown(PointerEventData data)
    {
        #region код для тестов
        List<DialogData> Dialog = new List<DialogData>() { new DialogData("???", "Ну чё ты"), new DialogData("???", "Ну как ты") };
        Dialogs dialogs = new Dialogs(Dialog);
        #endregion

        AllCharactersDialogs.Add(dialogs);

        if (AllCharactersDialogs.Count > DialogsNumber)
            DialogsNumber++;

        EventBusSystem.RaiseEvent<IDialogEvent>(ev => ev.CreateDialog(AllCharactersDialogs[DialogsNumber]));
    }
}
