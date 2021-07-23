using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class Villagers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Birthday { get; set; }

        public int UserProfileId { get; set; }

        public bool IsResiding { get; set; }
    }
}
