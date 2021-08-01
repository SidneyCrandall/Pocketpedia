using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class ApiFish
    {
        public int id { get; set; }
        [JsonPropertyName("file-name")]
        public string filename { get; set; }
        public Name name { get; set; }
        public Availability availability { get; set; }
        public string shadow { get; set; }
        public int price { get; set; }
        [JsonPropertyName("price-cj")]
        public int pricecj { get; set; }
        [JsonPropertyName("catch-phrase")]
        public string catchphrase { get; set; }
        [JsonPropertyName("museum-phrase")]
        public string museumphrase { get; set; }
        public string image_uri { get; set; }
        public string icon_uri { get; set; }
    }
}
