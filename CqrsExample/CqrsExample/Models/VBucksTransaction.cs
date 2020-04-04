using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsExample.Models
{
    public class VBucksTransaction
    {
        public Guid UserId { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
    }
}
