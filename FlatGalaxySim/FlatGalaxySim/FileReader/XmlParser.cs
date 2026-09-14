using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Xml.Linq;

namespace FlatGalaxySim.FileReader
{
    public class XmlParser : IFileParser
    {
        public List<Dictionary<string, string>> ParseContent(List<string> fileContent)
        {
            List<Dictionary<string, string>> parsedContent = [];

            XDocument xmlDoc = XDocument.Parse(string.Join(Environment.NewLine, fileContent));

            foreach (XElement element in xmlDoc.Root.Elements())
            {
                Dictionary<string, string> lineData = new Dictionary<string, string>();

                switch (element.Name.LocalName)
                {
                    case "planet":
                        lineData["type"] = "planet";
                        break;
                    case "asteroid":
                        lineData["type"] = "asteroid";
                        break;
                    default:
                        lineData["type"] = "unknown";
                        break;
                }
       
                foreach (XElement child in element.Elements())
                {
                    if (child.Name.LocalName == "position")
                    {
                        lineData["x"] = child.Element("x")?.Value ?? "";
                        lineData["y"] = child.Element("y")?.Value ?? "";
                        lineData["radius"] =child.Element("radius")?.Value ?? "";
                    }
                    else if (child.Name.LocalName == "speed")
                    {
                        lineData["vx"] = child.Element("x")?.Value ?? "";
                        lineData["vy"] = child.Element("y")?.Value ?? "";
                    }
                    else if (child.Name.LocalName == "neighbours")
                    {
                        string neighbours = string.Join(",", child.Elements("planet").Select(n => n.Value));
                        lineData["neighbours"] = neighbours;
                    }
                    else
                    {
                        lineData[child.Name.LocalName] = child.Value;
                    }
                }

                parsedContent.Add(lineData);
            }

            return parsedContent;
        }
    }
}
