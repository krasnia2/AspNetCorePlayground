using Couchbase;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using CqrsExample.Controllers;
using CqrsExample.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsExample.RequestHandlers
{
    public class SocialMediaRequestHandler : IRequestHandler<SocialMediaRequest>
    {
        private IBucket _bucket;

        public SocialMediaRequestHandler(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucket("usereventsource");
        }

        public async Task<Unit> Handle(SocialMediaRequest request, CancellationToken cancellationToken)
        {
            await _bucket.InsertAsync(new Document<SocialMediaUpdateEvent>
            {
                Id = Guid.NewGuid().ToString(),
                Content = new SocialMediaUpdateEvent(request.socialMedia)
            });
            return Unit.Value;
        }
    }

    public class SocialMediaUpdateEvent : EventSourceEvent
    {
        public SocialMedia Data { get; }
        public SocialMediaUpdateEvent(SocialMedia requestSocialMediaInfo): base(DateTime.Now, "SocialMediaUpdate")
        {
            Data = requestSocialMediaInfo;
        }
    }
}
