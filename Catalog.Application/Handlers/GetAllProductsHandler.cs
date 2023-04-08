using Amazon.Runtime.Internal;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
    {

        private readonly IProductRepository _repository;
        public GetAllProductsHandler(IProductRepository productRepository) {
            _repository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _repository.GetProducts();
            var productResponseList =ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
            return productResponseList;
        }
    }
}
