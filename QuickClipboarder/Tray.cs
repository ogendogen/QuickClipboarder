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
            _tray.Icon = Properties.Resources.clipboard_icon;
            _tray.Text = "Tray test";
            _tray.Visible = true;

            _tray.ContextMenuStrip = new ContextMenuStrip();
            _tray.ContextMenuStrip.Items.Clear();
            ToolStripMenuItem menuItem = new ToolStripMenuItem("Menu");
            menuItem.DropDownItems.Add("Sample item", null, ItemClicked);
            _tray.ContextMenuStrip.Items.Add(menuItem);
            _tray.ContextMenuStrip.Items.Add("Konfiguruj", null, new EventHandler(ConfigureClicked));
            _tray.ContextMenuStrip.Items.Add("Wyjście", null, new EventHandler(ExitClicked));
        }

        private void ItemClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Sample action");
        }

        private void ConfigureClicked(object sender, EventArgs e)
        {
            _mainWindow.Visibility = System.Windows.Visibility.Visible;
        }

        private void ExitClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
