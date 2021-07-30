using System.Text.Json.Serialization;

namespace Pocketpedia.Models
{

    public class Availability
    {
        [JsonPropertyName("month-northern")]
        public string monthnorthern { get; set; }
        [JsonPropertyName("month-southern")]
        public string monthsouthern { get; set; }
        public string time { get; set; }
        public bool isAllDay { get; set; }
        public bool isAllYear { get; set; }
        public string location { get; set; }
        public string rarity { get; set; }
        [JsonPropertyName("month-array-northern")]
        public int[] montharraynorthern { get; set; }
        [JsonPropertyName("month-array-southern")]
        public int[] montharraysouthern { get; set; }
        [JsonPropertyName("time-array")]
        public int[] timearray { get; set; }
    }

}
