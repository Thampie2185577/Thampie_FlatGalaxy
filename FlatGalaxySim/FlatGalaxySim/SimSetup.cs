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
        public void StartSetup(string filePath)
        {
            if (reader == null) return;

            List<string> fileContents =  reader.ReadFile(filePath);

            parser = GetParser(reader.GetFileType());

            if (parser == null) return; 

            List<Dictionary<string, string>> contents = parser.ParseContent(fileContents);

            if (fileContents.Count == 0){ MessageBox.Show("File is empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
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
