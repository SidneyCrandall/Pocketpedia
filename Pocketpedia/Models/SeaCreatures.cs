using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class SeaCreatures
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int SeasonAvailability { get; set; }

        public int UserPofileId { get; set; }

        public bool Caught { get; set; }
    }
}
