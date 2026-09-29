using FlatGalaxySim.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.States
{
    public class ExplodeState : State
    {
        private int MAXENTITIES = 5;

        public override void Handle()
        {
            List<Dictionary<string, string>> newBodies = new List<Dictionary<string, string>>();
            Random rnd = new Random();
            for (int i = MAXENTITIES; i > 0; i--)
            {
                newBodies.Add(new Dictionary<string, string>{
                    { "type", "Asteroid" },
                    { "x", this.bodyContext.Position.x.ToString() },
                    { "y", this.bodyContext.Position.y.ToString() },
                    { "vx", (rnd.NextDouble() * (5.0 - -5.0)).ToString() },
                    { "vy", (rnd.NextDouble() * (5.0 - -5.0)).ToString() },
                    { "radius", "5" },
                    { "color", "black" },
                    { "oncollision", "bounce"}
                });
            }

            newBodies.ForEach(b =>
            {
                this.bodyContext.Galaxy.AddNewBodies(CelestialBodyFactory.CreateCelestialBody(b));
            });

            this.bodyContext.Galaxy.Canvas.Children.Remove(this.bodyContext.Ellipse);
            this.bodyContext.TransitionState(new DisappearState());

        }
    }
}
