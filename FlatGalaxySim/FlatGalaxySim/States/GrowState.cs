using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FlatGalaxySim.States
{
    public class GrowState : State
    {
        public override void Handle()
        {
            if(bodyContext.Radius != 5)
            {
                var anim = new DoubleAnimation(bodyContext.Ellipse.Width,  bodyContext.Radius * 2, TimeSpan.FromSeconds(0.3));
                bodyContext.Ellipse.BeginAnimation(Ellipse.WidthProperty, anim);
                bodyContext.Ellipse.BeginAnimation(Ellipse.HeightProperty, anim);
                bodyContext.Radius += 1;
            }

            if (bodyContext.Radius == 5) this.bodyContext.TransitionState(new ExplodeState());
          
        }
    }
}
