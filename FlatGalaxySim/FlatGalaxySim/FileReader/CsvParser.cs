using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace FlatGalaxySim.FileReader
{
    public class CsvParser : IFileParser
    {
        // function that parse list string into list of dictionary with key as header and value as value
        public List<Dictionary<string, string>> ParseContent(List<string> fileContent)
        {
            List<Dictionary<string, string>> parsedContent = [];
            string sFirstContent = fileContent[0];

            string[] headers = sFirstContent.Split(';');

            foreach (string line in fileContent.Skip(1))
            {
                Dictionary<string, string> lineData = new Dictionary<string, string>();
                string[] values = line.Split(';');

                for (int i = 0; i < headers.Length; i++)
                {
                   lineData[headers[i]] = values[i];
                }

                parsedContent.Add(lineData);
            }

            return parsedContent;
        }
    }
}
