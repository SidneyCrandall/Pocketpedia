using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class Art
    {
        public int Id { get; set; }

        public int AcnhApiId { get; set; }

        public string Name { get; set; }
        
        public string ImageUrl { get; set; }

        public int UserProfileId { get; set; }

        public bool HasFake { get; set; }

        public bool Obtained { get; set; }
    }
}
