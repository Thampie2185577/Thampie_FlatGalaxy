using FlatGalaxySim.FileReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace FlatGalaxySim
{
    /// <summary>
    /// Interaction logic for Starter.xaml
    /// </summary>
    public partial class Starter : Window
    {
        private Grid? gUilocal = null;
        private Grid? gUiWeb = null;
        private Reader? reader = null;
        private string path = "";

        public Starter()
        {
            InitializeComponent();
            gUilocal = (Grid)FindName("UiLocal");
            gUiWeb = (Grid)FindName("UiWeb");
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (reader == null || path == "") { return; }
            MainWindow main = new MainWindow(reader, path);
            main.Show();
            this.Close();
        }

        private void LocalOption(object sender, RoutedEventArgs e)
        {
            gUilocal.Visibility = Visibility.Visible;
            gUiWeb.Visibility = Visibility.Collapsed;


            reader = new LocalReader();
        }
        private void WebOption(object sender, RoutedEventArgs e)
        {
            gUilocal.Visibility = Visibility.Collapsed;
            gUiWeb.Visibility = Visibility.Visible;
            reader = new WebReader();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog() {
                Title = "Select a file",
                Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt"
            };
            TextBlock txtPath = (TextBlock)FindName("txtPath");
            string text = "";

            if (openFileDialog.ShowDialog() == true)
                text = openFileDialog.FileName;

            if(text != "")
                txtPath.Text = text;
                path = text;
        }
    }
}
