using System;
using System.Collections.Generic;
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
        public Starter()
        {
            InitializeComponent();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(/* pass data if needed */);
            main.Show();
            this.Close();
        }
    }
}
