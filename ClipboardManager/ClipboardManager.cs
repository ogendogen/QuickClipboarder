using System;
using DataManager;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.Specialized;

namespace Core
{
    internal class ClipboardManager
    {
        internal DataManager.DataManager DataManager { get; set; }
        internal ClipboardManager(DataManager.DataManager dataManager)
        {
            DataManager = dataManager;
        }

        internal void CopyTextToClipboard(string text)
        {
            Clipboard.SetText(text);
        }

        internal void CopyImageToClipboard(string path)
        {
            BitmapSource bitMapSource = new BitmapImage(new Uri(path));
            Clipboard.SetImage(bitMapSource);
        }

        internal void CopyFileToClipboard(string path)
        {
            StringCollection files = new StringCollection();
            files.Add(path);

            Clipboard.SetFileDropList(files);
        }

        internal void CopyURLToClipboard(string url)
        {
            CopyTextToClipboard(url);
        }
    }
}
