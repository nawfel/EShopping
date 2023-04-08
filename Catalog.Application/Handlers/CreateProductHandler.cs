using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepo;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepo= productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<Product>(request);
            if(productEntity is null)
            
            {
                throw new ApplicationException("there is an issue");
            }
            var newProduct = await _productRepo.CreateProduct(productEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }
    }
}
