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
        private int raduis = 0;
        private BodyColor bodyColor;
        private string onCollision = "";

        public string Type { get => type; set => type = value; }
        public Position Position { get => position; set => position = value; }
        public Velocity Velocity { get => velocity; set => velocity = value; }
        public int Raduis { get => raduis; set => raduis = value; }
        public BodyColor BodyColor { get => bodyColor; set => bodyColor = value; }
        public string OnCollision { get => onCollision; set => onCollision = value; }


        public void Draw(Canvas canvas)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = Raduis * 2,
                Height = Raduis * 2,
                Fill = new SolidColorBrush(bodyColor.color),
                
            };
            Canvas.SetLeft(ellipse, Position.x - Raduis);
            Canvas.SetTop(ellipse, Position.y - Raduis);
            canvas.Children.Add(ellipse);
        }
    }
}
