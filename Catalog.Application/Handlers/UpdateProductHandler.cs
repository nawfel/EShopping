﻿using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _repository= productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _repository.UpdateProduct(new Core.Entities.Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price,
                Summary = request.Summary,
                Brands = request.Brands,
                Types = request.Types,

            });
            return productEntity;
        }
    }
}
