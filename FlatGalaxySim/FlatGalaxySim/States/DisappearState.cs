using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.States
{
    public class DisappearState : State
    {
        public override void Handle()
        {
            if (this.bodyContext.Galaxy.Canvas.Children.Contains(this.bodyContext.Ellipse))
                this.bodyContext.Undraw();
            this.bodyContext.IsDrawable = false;
        }
    }
}
