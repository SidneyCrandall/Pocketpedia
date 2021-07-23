using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pocketpedia.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string FirebaseUserId { get; set; }

        // The following will be manually entered by the user when registering an account 
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string IslandName { get; set; }

        [Required]
        public string IslandPhrase { get; set; }
    }
}
