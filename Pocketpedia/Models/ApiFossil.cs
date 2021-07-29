﻿using System;
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
