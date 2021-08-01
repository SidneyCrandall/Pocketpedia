using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class ApiArt
    {
        public int id { get; set; }
        [JsonPropertyName("file-name")]
        public string filename { get; set; }
        public Name name { get; set; }
        public bool hasFake { get; set; }
        [JsonPropertyName("buy-price")]
        public int buyprice { get; set; }
        [JsonPropertyName("sell-price")]
        public int sellprice { get; set; }
        public string image_uri { get; set; }
        [JsonPropertyName("museum-desc")]
        public string museumdesc { get; set; }
    }
}
