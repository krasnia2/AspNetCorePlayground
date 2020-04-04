using CqrsExample.Models;
using MediatR;
using System.Collections.Generic;

namespace CqrsExample.Controllers
{
    public class GetUsersRequest : IRequest<List<UserInfo>>
    {
        private int pageNumber;
        private int pageSize;

        public GetUsersRequest(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
        }
    }
}