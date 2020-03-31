using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;

namespace QuickClipboarder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Tray Tray { get; set; }
        public DataManager.DataManager DataManager { get; set; }
        public MenuBuilder MenuBuilder { get; set; }
        public event EventHandler ClickEvent;
        public ActionsManager ActionManager { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Visibility = Visibility.Hidden;
            Tray = new Tray(this);
            DataManager = new DataManager.DataManager();
            ClickEvent += ItemClickedEvent;
            MenuBuilder = new MenuBuilder(ClickEvent, DataManager.Config.Events);
            Tray.LoadMenuItems(MenuBuilder.Menu);
            ActionManager = new ActionsManager(DataManager);
            MainTable.ItemsSource = DataManager.Config.Events;
        }

        private void ItemClickedEvent(object sender, EventArgs e)
        {
            ActionManager.ItemsHandler((sender as ToolStripItem).Text);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataManager.SaveConfig();
            MenuBuilder.Rebuild();
            Tray.LoadMenuItems(MenuBuilder.Menu);

            System.Windows.MessageBox.Show("Konfiguracja zapisana", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
