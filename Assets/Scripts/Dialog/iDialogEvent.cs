using EventBus;

namespace Dialog
{
    public interface IDialogEvent : IGlobalSubscriber
    {
        /// <summary>
        /// создает диалоговое окно
        /// </summary>
        /// <param name="dialogs">Наши диалоги</param>
        public void CreateDialog(Dialogs dialogs);

        /// <summary>
        /// Переходит к следующему диалогу
        /// </summary>
        public void ContinueDialog();
    }
}
