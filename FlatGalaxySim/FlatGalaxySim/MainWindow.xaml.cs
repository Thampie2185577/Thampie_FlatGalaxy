using FlatGalaxySim.Entities;
using FlatGalaxySim.FileReader;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlatGalaxySim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            Canvas canvas = Flatgalaxy_Canvas;
            SimSetup setup = new SimSetup(new LocalReader());

            FlatGalaxy galaxy = new FlatGalaxy(canvas);
            setup.StartSetup("./src/planetsExtended.csv", galaxy);

            if(galaxy.CelestialBodies != null)
                galaxy.runSimulation();
        }
    }
}