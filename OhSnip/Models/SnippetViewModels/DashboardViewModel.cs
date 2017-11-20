using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhSnip.Models.SnippetViewModels
{
    public class DashboardViewModel
    {
        public List<Snippet> Snippets { get; set; }

        public DashboardViewModel()
        {
            Snippets = new List<Snippet>();
        }
    }
}
