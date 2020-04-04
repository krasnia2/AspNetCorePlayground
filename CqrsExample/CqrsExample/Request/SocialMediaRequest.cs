using CqrsExample.Models;
using MediatR;

namespace CqrsExample.Controllers
{
    public class SocialMediaRequest : IRequest
    {
        public SocialMedia socialMedia;

        public SocialMediaRequest(SocialMedia socialMedia)
        {
            this.socialMedia = socialMedia;
        }
    }
}