using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlatGalaxySim.FileReader
{
    public class LocalReader : Reader
    {
        //<summary> extracts file contents into list of strings </summary>
        public override List<string> ReadFile(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                MessageBox.Show(filePath + " does not exist. Please check the file path and try again.", "File Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<string>();
            }

            this.fileType = this.ExtractfileType(filePath);

            return File.ReadLines(filePath).ToList();
        }
    }
}
