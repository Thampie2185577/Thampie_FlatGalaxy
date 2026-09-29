using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.States
{
    public class BounceState : State
    {
        private int bounceCounter = 0;
        public override void Handle()
        {
            if (bounceCounter < 5)
            {
                this.bodyContext.ChangeDirection();
                bounceCounter++;
            }
            else {
                this.bodyContext.TransitionState(new BlinkState());
            }
        }
    }
}
