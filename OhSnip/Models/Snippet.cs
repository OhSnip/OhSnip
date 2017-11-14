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
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
