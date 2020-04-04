using CqrsExample.Models;
using MediatR;

namespace CqrsExample.Controllers
{
    internal class VBucksTransactionRequest : IRequest
    {
        private VBucksTransaction transaction;

        public VBucksTransactionRequest(VBucksTransaction transaction)
        {
            this.transaction = transaction;
        }
    }
}