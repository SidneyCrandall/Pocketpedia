using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class ApiFossil
    {
        [JsonPropertyName("file-name")]
        public string filename { get; set; }
        public Name name { get; set; }
        public int price { get; set; }
        [JsonPropertyName("museum-phrase")]
        public string museumphrase { get; set; }
        public string image_uri { get; set; }
        public string partof { get; set; }
    }
}
