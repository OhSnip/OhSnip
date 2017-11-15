using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OhSnip.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // TODO: Look at adding a numerical auto-incrementing Id to associate 
        // users and snippets.
        // public int UserId { get; set; }   
        public List<Snippet> Snippets { get; set; }

        public ApplicationUser()
        {
            Snippets = new List<Snippet>();
        }
    }
}
