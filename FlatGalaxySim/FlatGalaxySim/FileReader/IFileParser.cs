using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.FileReader
{
    public interface IFileParser
    {
        public List<Dictionary<string, string>> ParseContent(List<string> fileContent);
    }
}
