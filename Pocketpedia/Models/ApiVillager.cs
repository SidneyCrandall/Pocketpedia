using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class ApiVillager
    {
        public int id { get; set; }
        [JsonPropertyName("file-name")]
        public string filename { get; set; }
        public Name name { get; set; }
        public string personality { get; set; }
        [JsonPropertyName("birthday-string")]
        public string birthdaystring { get; set; }
        public string birthday { get; set; }
        public string species { get; set; }
        public string gender { get; set; }
        public string subtype { get; set; }
        public string hobby { get; set; }
        [JsonPropertyName("catch-phrasee")]
        public string catchphrase { get; set; }
        public string icon_uri { get; set; }
        public string image_uri { get; set; }
        [JsonPropertyName("bubble-color")]
        public string bubblecolor { get; set; }
        [JsonPropertyName("text-color")]
        public string textcolor { get; set; }
        public string saying { get; set; }
        public CatchTranslations catchtranslations { get; set; }
    }

    public class CatchTranslations
    {
        [JsonPropertyName("catch-USen")]
        public string catchUSen { get; set; }
        public string catchEUen { get; set; }
        public string catchEUde { get; set; }
        public string catchEUes { get; set; }
        public string catchUSes { get; set; }
        public string catchEUfr { get; set; }
        public string catchUSfr { get; set; }
        public string catchEUit { get; set; }
        public string catchEUnl { get; set; }
        public string catchCNzh { get; set; }
        public string catchTWzh { get; set; }
        public string catchJPja { get; set; }
        public string catchKRko { get; set; }
        public string catchEUru { get; set; }
    }

}
