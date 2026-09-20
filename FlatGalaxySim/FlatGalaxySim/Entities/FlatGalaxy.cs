using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace FlatGalaxySim.Entities
{
    public class FlatGalaxy
    {
       private Canvas mainCanvas;
       public List<CelestialBody> celestials;
       public List<CelestialBody> CelestialBodies { get => celestials; set => celestials = value; }

       private TimeSpan lastTime = TimeSpan.Zero;

       public Canvas Canvas { get { return mainCanvas; }}
       public bool IsRunning { get; set; } = false;

       public FlatGalaxy(Canvas canvas)
       {
          this.mainCanvas = canvas;
          CelestialBodies = new List<CelestialBody>();
       }


        public void SetBodies()
        {
            if(celestials.Count == 0 ) { return; }

            foreach (var body in celestials)
            {
                body.Galaxy = this;
            }
        }

        public void runSimulation() {

            try
            {
                if (Canvas == null) throw new ArgumentNullException("Canvas cannot be null.");

                if (celestials.Count < 0) throw new ArgumentNullException("CelestialBodies cannot be null.");
                else { IsRunning = true; }


                
                DrawBodies();
                IsRunning = true;
                CompositionTarget.Rendering += OnRendering;

            }
            catch (Exception e)
            {

                  MessageBox.Show("Error:" + e, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }    
        }


        private void DrawBodies() {

            //this.Canvas.Children.Clear();
            foreach (var body in celestials)
            {   
                body.Draw();
            }
        }

        private double TIMESCALE = 25;
        private void OnRendering(object sender, EventArgs e)
        {
            var now = ((RenderingEventArgs)e).RenderingTime;
            if (lastTime == TimeSpan.Zero) { lastTime = now; return; }

            double dt = (now - lastTime).TotalSeconds * TIMESCALE;
            if (dt <= 0) return;  
            lastTime = now;

            foreach (var body in celestials)
            {
                body.MoveBody(
                    dt, 
                    Application.Current.MainWindow.ActualWidth, 
                    Application.Current.MainWindow.ActualHeight
                    );       
            }
        }
    }
}
