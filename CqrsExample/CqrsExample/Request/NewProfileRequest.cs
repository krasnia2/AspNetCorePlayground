using CqrsExample.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsExample.Request
{
    public class NewProfileRequest : IRequest
    {
        public NewUser newUser { get; }
        public NewProfileRequest(NewUser newUser)
        {
            this.newUser = newUser;
        }
    }
}
