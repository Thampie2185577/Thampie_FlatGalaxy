using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Memento
{
    public class SimCareTaker
    {
        private List<GalaxyMemento> galaxyMementos = new List<GalaxyMemento>();

        private FlatGalaxy galaxy = null;

        public SimCareTaker(FlatGalaxy galaxy)
        {
            this.galaxy = galaxy;
        }

        public void BackUp()
        {
            this.galaxyMementos.Add(galaxy.Save());
        }

        public void Undo(int steps = 60)
        {
            try
            {
                if (galaxyMementos.Count == 0) { return; }

                GalaxyMemento? target = null;

                for (int i = 0; i < steps && galaxyMementos.Count > 0; i++)
                {
                    target = galaxyMementos[galaxyMementos.Count - 1];
                    galaxyMementos.RemoveAt(galaxyMementos.Count - 1);
                }

                if (target == null) return;

                galaxy.Restore(target);
            }
            catch (Exception ex) {

                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

    }
}
