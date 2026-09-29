using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.States
{
    public abstract class State
    {
        protected CelestialBody bodyContext = null;

        public void SetContext(CelestialBody context)
        {
            bodyContext = context;
        }

        public abstract void Handle();
    }
}
