using Couchbase;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using CqrsExample.Models;
using CqrsExample.Request;
using MediatR;
using System;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsExample.RequestHandlers
{
    public class NewProfileRequestHandler : IRequestHandler<NewProfileRequest>
    {
        private IBucket _bucket;

        public NewProfileRequestHandler(IBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucket("usereventsource");
        }

        public async Task<Unit> Handle(NewProfileRequest request, CancellationToken cancellationToken)
        {
            await _bucket.InsertAsync(new Document<NewProfileEvent>
            {
                Id = Guid.NewGuid().ToString(),
                Content = new NewProfileEvent(request)
            });
            return Unit.Value;
        }
    }

    public class NewProfileEvent : EventSourceEvent
    {
        public NewUser Data { get; }

        public NewProfileEvent(NewProfileRequest request) : base(DateTime.Now, "newProfile")
        {
            Data = request.newUser;
        }
    }
}
