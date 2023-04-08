using Amazon.Runtime.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Catalog.Application.Queries
{
    public class DeleteProductByIdQuery :IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteProductByIdQuery(string id)
        {
            Id = id;
        }
    }
}
