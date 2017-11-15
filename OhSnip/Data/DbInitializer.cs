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
        }
    }
}
