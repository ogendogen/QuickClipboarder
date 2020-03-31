using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Core
{
    public class ActionsManager
    {
        internal ClipboardManager ClipboardManager { get; set; }
        internal CustomActionsManager CustomActionsManager { get; set; }
        public DataManager.DataManager DataManager { get; set; }

        public ActionsManager(DataManager.DataManager dataManager)
        {
            DataManager = dataManager;
            ClipboardManager = new ClipboardManager(dataManager);
            CustomActionsManager = new CustomActionsManager();
        }

        public void ItemsHandler(string itemName)
        {
            var choosenEvent = DataManager.Config.Events.Where(ev => ev.Name == itemName).First();

            if (choosenEvent.Action == Types.Action.Copy)
            {
                switch(choosenEvent.Type)
                {
                    case Types.Type.Text:
                        ClipboardManager.CopyTextToClipboard(choosenEvent.Source);
                        break;

                    case Types.Type.Image:
                        ClipboardManager.CopyImageToClipboard(choosenEvent.Source);
                        break;

                    case Types.Type.File:
                        ClipboardManager.CopyFileToClipboard(choosenEvent.Source);
                        break;

                    case Types.Type.Url:
                        ClipboardManager.CopyURLToClipboard(choosenEvent.Source);
                        break;
                }
            }
            else if (choosenEvent.Action == Types.Action.Open)
            {
                CustomActionsManager.OpenURL(choosenEvent.Source);
            }
        }
    }
}
