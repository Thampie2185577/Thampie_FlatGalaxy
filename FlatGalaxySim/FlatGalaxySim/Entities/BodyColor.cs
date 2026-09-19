using System.Collections.Generic;
using System.Windows.Media;

namespace FlatGalaxySim.Entities
{
    public struct BodyColor
    {
        public Color color { get; set; }

        private static readonly Dictionary<string, Color> colorDictionary =
            new Dictionary<string, Color>()
            {
                { "blue", Color.FromArgb(255, 0, 0, 255) },
                { "purple", Color.FromArgb(255, 128, 0, 128) },
                { "black", Color.FromArgb(255, 0, 0, 0) },
                { "brown", Color.FromArgb(255, 165, 42, 42) },
                { "grey", Color.FromArgb(255, 128, 128, 128) },
                { "orange", Color.FromArgb(255, 255, 165, 0) }
            };

        public BodyColor(string colorKey)
        {
            color = colorDictionary.ContainsKey(colorKey.ToLower())
                ? colorDictionary[colorKey.ToLower()]
                : colorDictionary["black"];
        }
    }
}