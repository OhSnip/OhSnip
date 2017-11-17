using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhSnip.Models
{
    public class Snippet : BaseEntity
    {
        public int SnippetId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Code { get; set; }
        public string Link { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
