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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuickClipboarder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Tray Tray { get; set; }
        public DataManager.DataManager DataManager { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Visibility = System.Windows.Visibility.Hidden;
            Tray = new Tray(this);
            DataManager = new DataManager.DataManager();
            MainTable.ItemsSource = DataManager.Config.Events;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataManager.SaveConfig();
            MessageBox.Show("Konfiguracja zapisana", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
