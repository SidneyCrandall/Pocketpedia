using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class Bugs
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int LocationId { get; set; }
        //public Location Location { get; set; }

        public int seasonAvailabilityId { get; set; }
        // public SeasonAvailability SeasonAvailability { get; set; }

        public string ImageUrl { get; set; }

        public int UserProfileId { get; set; }
        // public UserProfile UserProfile { get; set; }

        public bool Caught { get; set; }
    }
}
