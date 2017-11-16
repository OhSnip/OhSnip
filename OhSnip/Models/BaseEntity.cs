using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhSnip.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
