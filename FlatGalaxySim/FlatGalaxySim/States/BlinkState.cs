using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FlatGalaxySim.States
{
    public class BlinkState : State
    {
        private Color tempColor =  Color.FromArgb(255, 250, 239, 157);

        public override void Handle()
        {
            try
            {
                if (this.bodyContext.isColliding)
                {
                    this.bodyContext.Ellipse.Fill = new SolidColorBrush(tempColor);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ResetState() {
            this.bodyContext.Ellipse.Fill = new SolidColorBrush(this.bodyContext.BodyColor.color);
        }
    }
}
