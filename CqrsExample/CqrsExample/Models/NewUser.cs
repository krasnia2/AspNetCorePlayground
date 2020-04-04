using System;

namespace CqrsExample.Models
{
    public class NewUser
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string language { get; set; }
    }
}