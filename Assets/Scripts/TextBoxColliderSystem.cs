using Dialog;
using EventBus;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextBoxColliderSystem : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        EventBusSystem.RaiseEvent<IDialogEvent>(ev => ev.ContinueDialog());
    }
}
