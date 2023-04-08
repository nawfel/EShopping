using Amazon.Runtime.Internal;
using Catalog.Application.Queries;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdQuery, bool>
    {

        private readonly IProductRepository _productRepo;

        public DeleteProductByIdHandler(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }
        public async Task<bool> Handle(DeleteProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepo.DeleteProduct(request.Id);
        }
    }
}
