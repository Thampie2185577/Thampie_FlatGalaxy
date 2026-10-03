using FlatGalaxySim.States;
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
        private List<CelestialBody> celestials = [];
        public List<CelestialBody> CelestialBodies { get => celestials; set => celestials = value; }

        public Canvas Canvas { get { return mainCanvas; } }
        private bool isRunning = false;

        public FlatGalaxy(Canvas canvas)
        {
            this.mainCanvas = canvas;
        }

        public void SetBodies()
        {
            if (celestials.Count == 0) { return; }

            foreach (var body in celestials)
            {
                if (body.Galaxy != null) continue;
                body.Galaxy = this;
            }
        }

        public void runSimulation()
        {
            try
            {
                if (Canvas == null) throw new ArgumentNullException("Canvas cannot be null.");

                if (celestials.Count == 0) throw new ArgumentNullException("CelestialBodies cannot be null.");
                else { isRunning = true; }

                if (isRunning) {
                    DrawBodies();
                    CompositionTarget.Rendering += OnRendering;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error:" + e, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DrawBodies() {
            
            foreach (var body in celestials)
            {
                if (body.IsDrawable) body.Draw();
            }
        }

        private double TIMESCALE = 25;
        private TimeSpan lastTime = TimeSpan.Zero;
        private void OnRendering(object sender, EventArgs e)
        {
            var now = ((RenderingEventArgs)e).RenderingTime;
            if (lastTime == TimeSpan.Zero) { lastTime = now; return; }

            double dt = (now - lastTime).TotalSeconds * TIMESCALE;
            if (dt <= 0) return;
            lastTime = now;

            List<CelestialBody> chosenBodyToDelete = new List<CelestialBody>();

            if (newBodies.Count != 0)
            {
                newBodies.ForEach(b => { celestials.Add(b); });
                newBodies.Clear();
            }

            foreach (var body in celestials)
            {
                //check if the body is allowed to be drawn if noet then must be deleted from celestialbodies list;
                if (body.IsDrawable == false) { chosenBodyToDelete.Add(body); continue; };

                body.MoveBody(
                    dt,
                    this.Canvas.ActualWidth,
                    this.Canvas.ActualHeight
                    );

                CollisionDetection(body);
            }

            if (chosenBodyToDelete != null)
            {
                DeleteBody(chosenBodyToDelete);
            }
        }

        //makes the sim faster
        public void RunSimFaster() => TIMESCALE += 10;

        //makes the sim slower
        public void RunSimSlower() 
        {
            TIMESCALE -= 10;

            if (TIMESCALE < 0)
            {
                TIMESCALE = 0;
            }
        }

        //this pauze or resume the sim
        public void PauseOrResume()  
        {
            isRunning = !isRunning;

            if (isRunning)
            {
                lastTime = TimeSpan.Zero;
                CompositionTarget.Rendering += OnRendering;
            }
            else
            {
                CompositionTarget.Rendering -= OnRendering;
            }
        }
        
        private List<CelestialBody> newBodies = new List<CelestialBody>();
        public void AddNewBodies(CelestialBody newBody)
        {
            newBody.Galaxy = this;
            newBody.Draw();
            newBodies.Add(newBody);
        }

        private void DeleteBody(List<CelestialBody> chosenBodies)
        {
            foreach (var body in chosenBodies)
                this.celestials.Remove(body);
        }

        private void CollisionDetection(CelestialBody body)
        {
            bool anyCollision = false;
            foreach (var secondBody in celestials)
            {
                if(secondBody.Equals(body)) continue;

                double dx = secondBody.Position.x - body.Position.x;
                double dy = secondBody.Position.y - body.Position.y;

                double radiusSum = body.Radius + secondBody.Radius;
                bool collision = (dx * dx + dy * dy) <= (radiusSum * radiusSum);

                if (collision)
                {
                    anyCollision = true;
                }
            }

            body.isColliding = anyCollision;
            body.runState();
        }
    }
}
