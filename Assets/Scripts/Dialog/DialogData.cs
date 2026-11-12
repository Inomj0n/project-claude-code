
using NUnit.Framework;
using System.Collections.Generic;

namespace Dialog
{
    public struct Dialogs
    {
        private List<DialogData> dialogs;
        private int DialogNumber;

        public Dialogs(List<DialogData> Dialogs)
        {
            dialogs = Dialogs;
            DialogNumber = -1;
        }

        public DialogData? GetNextDialog()
        {
            DialogNumber++;
            return DialogNumber < dialogs.Count ? dialogs[DialogNumber] : null;
        }
    }

    /// <summary>
    /// Данные диалога
    /// </summary>
    public struct DialogData
    {
        
        public string name;
        public string dialog;

        /// <param name="Name">Имя персонажа</param>
        /// <param name="Dialog">Диалог</param>
        public DialogData(string Name, string Dialog)
        {
            name = Name;
            dialog = Dialog;
        }
    }
}