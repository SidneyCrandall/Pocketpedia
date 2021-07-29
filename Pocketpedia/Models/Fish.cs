using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class Fish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int LocationId { get; set; }

        public int UserProfileId { get; set; }

        public int AcnhApiId { get; set; }

        public bool Caught { get; set; }
    }
}
