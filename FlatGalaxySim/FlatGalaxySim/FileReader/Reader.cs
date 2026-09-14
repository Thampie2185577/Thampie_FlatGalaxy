using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.FileReader
{
    public abstract class Reader
    {
        
        private Dictionary<string, FileType> FileExtension = new Dictionary<string, FileType>
            {
                { ".csv", FileType.CSV },
                { ".xml", FileType.XML }
            };

        protected FileType fileType;
        public abstract List<string> ReadFile(string filePath);

        // Method to extract the file type based on the file extension
        protected FileType ExtractfileType(string path)
        {
            string extension = Path.GetExtension(path).ToLower();  
            if (FileExtension.ContainsKey(extension))
            {
                fileType = FileExtension[extension];
            }
            else
            {
                throw new NotSupportedException("File type not supported");
            }
            return fileType;
        }

        public FileType GetFileType()
        {
            return fileType;
        }
    }
}
