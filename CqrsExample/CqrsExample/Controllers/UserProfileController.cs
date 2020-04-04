using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using CqrsExample.Models;
using CqrsExample.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CqrsExample.Controllers
{
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ILogger<UserProfileController> _logger;
        private readonly IBucket _bucket;
        private readonly IMediator _mediator;

        public UserProfileController(ILogger<UserProfileController> logger, IBucketProvider bucket, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            _bucket = bucket.GetBucket("usereventsource");
        }

        [HttpGet]
        [Route("/api/getUser")]
        public async Task<IActionResult> GetUsers(int pageNumber, int pageSize)
        {
            var request = new GetUsersRequest(pageNumber, pageSize);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("/api/createUser")]
        public async Task<IActionResult> CreateUser([FromBody] NewUser userProfile)
        {
            var request = new NewProfileRequest(userProfile);
            await _mediator.Send(request);
            return Ok("User has been created");
        }

        [HttpPost]
        [Route("/api/addSocial")]
        public async Task<IActionResult> AddSocial([FromBody] SocialMedia socialMedia)
        {
            var request = new SocialMediaRequest(socialMedia);
            await _mediator.Send(request);
            return Ok("Social has been created");
        }

        [HttpPut]
        [Route("/api/VbucksTransaction")]
        public async Task<IActionResult> VBucksTransaction(VBucksTransaction transaction)
        {
            var request = new VBucksTransactionRequest(transaction);
            await _mediator.Send(request);
            return Ok("User has been created");
        }


    }
}
