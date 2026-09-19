using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlatGalaxySim.Entities
{
    public class FlatGalaxy
    {
       private Canvas Canvas;
       public List<CelestialBody> CelestialBodies { get; set; }
       public bool IsRunning { get; set; } = false;

        public FlatGalaxy(Canvas canvas)
       {
          Canvas = canvas;
          CelestialBodies = new List<CelestialBody>();
       }


        public void runSimulation() {

            try
            {
                if (Canvas == null) throw new ArgumentNullException("Canvas cannot be null.");

                if (CelestialBodies.Count < 0) throw new ArgumentNullException("CelestialBodies cannot be null.");
                else { IsRunning = true; }


                //while (IsRunning) { 
                    
    
                //}
                DrawBodies();

            }
            catch (Exception e)
            {

                  MessageBox.Show("Error:" + e, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }    
        }


        private void DrawBodies() {

            foreach (var body in CelestialBodies)
            {
                body.Draw(Canvas);
            }
        }
    }
}
