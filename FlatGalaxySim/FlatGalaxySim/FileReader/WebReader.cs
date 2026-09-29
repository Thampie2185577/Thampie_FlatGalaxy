using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.FileReader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;

  
        public class WebReader : Reader
        {
            // One shared instance; creating a new HttpClient per call causes socket exhaustion
            private static readonly HttpClient Client = new HttpClient();

            public override List<string> ReadFile(string filePath)
            {
                if (!Uri.TryCreate(filePath, UriKind.Absolute, out Uri uri) ||
                    (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                {
                    throw new ArgumentException("filePath must be a valid http/https URL.", nameof(filePath));
                }

                var lines = new List<string>();

                try
                {
                    using (Stream stream = Client.GetStreamAsync(uri).GetAwaiter().GetResult())
                    using (var reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    throw new IOException($"Failed to download '{filePath}': {ex.Message}", ex);
                }

                return lines;
            }
        }
    }

