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
        public event EventHandler ItemClickedEvent;
        public DataManager.DataManager DataManager { get; set; }

        public ActionsManager(DataManager.DataManager dataManager)
        {
            DataManager = dataManager;
            ClipboardManager = new ClipboardManager(dataManager);
            CustomActionsManager = new CustomActionsManager();
            ItemClickedEvent += ActionsManager_ItemClickedEvent;
        }

        private void ActionsManager_ItemClickedEvent(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            string name = item.Text;
            var choosenEvent = DataManager.Config.Events.Where(ev => ev.Name == name).First();

            if (choosenEvent.Action == Types.Action.Copy)
            {
                switch(choosenEvent.Type)
                {
                    case Types.Type.Text:
                        CopyTextToClipboard(choosenEvent.Source);
                        break;

                    case Types.Type.Image:
                        CopyImageToClipboard(choosenEvent.Source);
                        break;

                    case Types.Type.File:
                        CopyFileToClipboard(choosenEvent.Source);
                        break;

                    case Types.Type.Url:
                        CopyURLToClipboard(choosenEvent.Source);
                        break;
                }
            }
            else if (choosenEvent.Action == Types.Action.Open)
            {
                OpenURL(choosenEvent.Source);
            }
        }

        public void CopyTextToClipboard(string text)
        {
            ClipboardManager.CopyTextToClipboard(text);
        }

        public void CopyImageToClipboard(string path)
        {
            ClipboardManager.CopyImageToClipboard(path);
        }

        public void CopyFileToClipboard(string path)
        {
            ClipboardManager.CopyFileToClipboard(path);
        }

        public void CopyURLToClipboard(string url)
        {
            ClipboardManager.CopyURLToClipboard(url);
        }

        public void OpenURL(string url)
        {
            CustomActionsManager.OpenURL(url);
        }
    }
}
