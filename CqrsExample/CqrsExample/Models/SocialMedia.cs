using System;

namespace CqrsExample.Models
{
    public class SocialMedia
    {
        public Guid UserId { get; set; }
        public string socialMediaType { get; set; }
        public string handle { get; set; }
    }
}