using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ActionsManager
    {
        internal ClipboardManager ClipboardManager { get; set; }
        internal CustomActionsManager CustomActionsManager { get; set; }

        public ActionsManager(DataManager.DataManager dataManager)
        {
            ClipboardManager = new ClipboardManager(dataManager);
            CustomActionsManager = new CustomActionsManager();
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
