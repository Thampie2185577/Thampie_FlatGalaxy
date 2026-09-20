using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FlatGalaxySim.Entities
{
    public abstract class CelestialBody
    {
        private string type = "";
        private Position position;
        private Velocity velocity;
        private int radius = 0;
        private BodyColor bodyColor;
        private string onCollision = "";
        private FlatGalaxy? galaxy = null;
        private Ellipse? ellipse = null;


        public string Type { get => type; set => type = value; }
        public Position Position { get => position; set => position = value; }
        public Velocity Velocity { get => velocity; set => velocity = value; }
        public int Radius { get => radius; set => radius = value; }
        public BodyColor BodyColor { get => bodyColor; set => bodyColor = value; }
        public string OnCollision { get => onCollision; set => onCollision = value; }
        public FlatGalaxy Galaxy { get => galaxy; set => galaxy = value; }


        public void Draw()
        {
            ellipse = new Ellipse
            {
                Width = radius * 2,
                Height = radius * 2,
                Fill = new SolidColorBrush(bodyColor.color),
                
            };
            Canvas.SetLeft(ellipse, Position.x - radius);
            Canvas.SetTop(ellipse, Position.y - radius);
            if(galaxy != null) 
                galaxy.Canvas.Children.Add(ellipse);
        }


        public void MoveBody(double dt, double cWidth, double cHeight)
        {
            position.x += velocity.vx * dt;
            position.y += velocity.vy * dt;

            if (position.x - radius < 0)
            {
                position.x = radius;
                velocity.vx = -velocity.vx;
            }
            else if (position.x + radius > cWidth)
            {
                position.x = cWidth - radius;
                velocity.vx = -velocity.vx;
            }

            if (position.y - radius < 0)
            {
                position.y = radius;
                velocity.vy = -velocity.vy;
            }
            else if (position.y + radius > cHeight)
            {
                position.y = cHeight - radius;
                velocity.vy = -velocity.vy;
            }


           
               
            Canvas.SetLeft(ellipse, position.x - Radius);
            Canvas.SetTop(ellipse, position.y - Radius);
        }
    }
}
