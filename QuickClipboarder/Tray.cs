using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;

namespace QuickClipboarder
{
    public class Tray
    {
        private MainWindow _mainWindow;
        private NotifyIcon _tray;

        public Tray(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _tray = new NotifyIcon();

            _tray.Text = "Tray test";
            _tray.Visible = true;

            _tray.ContextMenuStrip = new ContextMenuStrip();
            _tray.ContextMenuStrip.Items.Clear();
            _tray.ContextMenuStrip.Items.Add("Test");
            _tray.ContextMenuStrip.Items.Add("Test2");
            _tray.ShowBalloonTip(5000, "Hi!", "Hello World!", ToolTipIcon.Info);
        }
    }
}
