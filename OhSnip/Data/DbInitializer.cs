using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OhSnip.Models;

namespace OhSnip.Data
{
    public class DbInitializer
    {
        public static void Initialize(OhSnipContext context)
        {
            context.Database.EnsureCreated();
            if (context.Snippets.Any())
            {
                Console.WriteLine("There is a database");
                return;
            }

            var snippets = new Snippet[]
            {
                new Snippet{Title="snip1", Description="snip1description", Language="C#", Code="code here"},
                new Snippet{Title="snip2", Description="snip2description", Language="C#", Code="code here also"}
            };
            foreach (Snippet s in snippets)
            {
                context.Snippets.Add(s);
            }
            context.SaveChanges();
        }
    }
}
