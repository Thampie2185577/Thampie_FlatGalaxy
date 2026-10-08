using FlatGalaxySim.Entities;
using FlatGalaxySim.Factories;
using FlatGalaxySim.FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlatGalaxySim
{
    public class SimSetup
    {
        private Reader? reader = null;
        private IFileParser? parser = null;
       
        public SimSetup(Reader reader)
        {
            this.reader = reader;
        }

        // This method starts the setup process by reading the file and parsing its contents.
        public void StartSetup(string filePath, FlatGalaxy galaxy)
        {
            if (reader == null) return;

            // Read the file contents
            List<string> fileContents =  reader.ReadFile(filePath);
            if (fileContents.Count == 0) { MessageBox.Show("File is empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            parser = GetParser(reader.GetFileType());

            if (parser == null) return;

            // Parse the file contents and create celestial bodies
            galaxy.CelestialBodies = CreateObjects(parser.ParseContent(fileContents));
        }

        // Creating objects
        private List<CelestialBody> CreateObjects(List<Dictionary<string, string>> contents)
        {
            List<CelestialBody> celestialBodies = new List<CelestialBody>();
            
            // List of planets names and its associated neighbours.
            List<(string planet, string neighbours)> sTempPlanets = [];

            contents.ForEach(content =>
            {
                CelestialBody? celestialBody = CelestialBodyFactory.CreateCelestialBody(content);
                if (celestialBody != null)
                {
                    celestialBodies.Add(celestialBody);
                }

                if (content["type"] == "Planet")
                {
                    sTempPlanets.Add((content["name"], content["neighbours"]));
                }
            });

            SetPlanetNeighbours(celestialBodies.OfType<Planet>().ToList(), sTempPlanets);

            return (celestialBodies.Count > 0) ? celestialBodies : throw new ArgumentException("there are no celestialbodies", nameof(celestialBodies)) ;
        }

        private void SetPlanetNeighbours(List<Planet> planets, List<(string planet, string neighbours)> sPlanets)
        {
            foreach (var sPlanet in sPlanets)
            {
                string[] neigboursNames = sPlanet.neighbours.Split(',');

                Planet planet = planets.Find(p => p.Name == sPlanet.planet)!;
                if(planet == null) continue;

                for (int i = 0; i < neigboursNames.Length; i++)
                {
                    planet.Neighbours.Add(planets.Find(p => p.Name == neigboursNames[i])!);
                }
            }
        }

        private IFileParser? GetParser(FileType fileType)
        {
            return fileType switch
            {
                FileType.XML => new XmlParser(),
                FileType.CSV => new CsvParser(),
                _ => null,
            };
        }   
    }
}
