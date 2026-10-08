using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Memento
{
    public class GalaxyMemento
    {
        public IReadOnlyList<BodyMemento> Bodies { get; }
        public double TimeScale { get; }

        public GalaxyMemento(IReadOnlyList<BodyMemento> bodies, double timeScale)
        {
            Bodies = bodies;
            TimeScale = timeScale;
        }
    }
}
