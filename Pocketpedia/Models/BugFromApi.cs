using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class BugFromApi
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Season { get; set; }

        public string ImageUrl { get; set; }

        public BugFromApi(string id, string name, string location, string season, string imageUrl)
        {
            Id = id;
            Name = name;
            Location = location;
            Season = season;
            ImageUrl = imageUrl;

        }
    }
}
