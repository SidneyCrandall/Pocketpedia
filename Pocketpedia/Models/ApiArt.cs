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

    public class Name
    {
        [JsonPropertyName("name-USen")]
        public string nameUSen { get; set; }
        public string nameEUen { get; set; }
        public string nameEUde { get; set; }
        public string nameEUes { get; set; }
        public string nameUSes { get; set; }
        public string nameEUfr { get; set; }
        public string nameUSfr { get; set; }
        public string nameEUit { get; set; }
        public string nameEUnl { get; set; }
        public string nameCNzh { get; set; }
        public string nameTWzh { get; set; }
        public string nameJPja { get; set; }
        public string nameKRko { get; set; }
        public string nameEUru { get; set; }
    }
}
