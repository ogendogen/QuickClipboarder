using System;
using DataManager;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.Specialized;

namespace Core
{
    public class ClipboardManager
    {
        public DataManager.DataManager DataManager { get; set; }
        public ClipboardManager(DataManager.DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public void CopyTextToClipboard(string text)
        {
            Clipboard.SetText(text);
        }

        public void CopyImageToClipboard(string path)
        {
            BitmapSource bitMapSource = new BitmapImage(new Uri(path));
            Clipboard.SetImage(bitMapSource);
        }

        public void CopyFileToClipboard(string path)
        {
            StringCollection files = new StringCollection();
            files.Add(path);

            Clipboard.SetFileDropList(files);
        }

        public void CopyURLToClipboard(string url)
        {
            CopyTextToClipboard(url);
        }
    }
}
