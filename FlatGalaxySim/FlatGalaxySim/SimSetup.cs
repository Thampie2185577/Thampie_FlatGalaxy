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
            List<Dictionary<string, string>> parsedContents = parser.ParseContent(fileContents);
            galaxy.CelestialBodies = CreateObject(parsedContents);
        }


        private List<CelestialBody> CreateObject(List<Dictionary<string, string>> contents)
        {
            List<CelestialBody> celestialBodies = new List<CelestialBody>();

            contents.ForEach(content =>
            {
                CelestialBody? celestialBody = CelestialBodyFactory.CreateCelestialBody(content);
                if (celestialBody != null)
                {
                    celestialBodies.Add(celestialBody);
                }
            });

            ArgumentNullException.ThrowIfNull(celestialBodies);
            return (celestialBodies.Count > 0) ? celestialBodies : throw new ArgumentException("there are no celestialbodies", nameof(celestialBodies)) ;
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
