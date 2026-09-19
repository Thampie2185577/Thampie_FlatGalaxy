using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Entities
{
    public class Planet : CelestialBody
    {
        private string name = "";
        private List<Planet> neighbours = [];

        public string Name { get => name; set => name = value; }

    }
}
