using FlatGalaxySim.Entities;
using FlatGalaxySim.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Factories
{
    public static class StateFactory
    {
        public static State CreateState(CelestialBody body, string collison)
        {
            State? state = null;

            state = collison switch
            {
                "blink" => new BlinkState(),
                "bounce" => new BounceState(),
                "disappear" => new DisappearState(),
                "explode" => new ExplodeState(),
                "grow" => new GrowState(),
                _ => throw new NotImplementedException(),
            };

            state.SetContext(body);
            return state;
        }
    }
}
