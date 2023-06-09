﻿using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CatalogController:ApiController
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductResponse),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{productName}", Name = "GetProductByName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByName(string productName)
        {
            var query = new GetProductByNameQuery(productName);

            var result = await _mediator.Send(query);

            return Ok(result);
        }
       
        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
        {
            var query = new GetAllBrandsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypesResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<TypesResponse>>> GetAllTypes()
        {
            var query = new GetAllTypesQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{brand}", Name = "GetProductByBrandName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByBrandName(string brand)
        {
            var query = new GetPRoductByBrandQuery(brand);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand productCommand)
        {
            var res = await _mediator.Send(productCommand);
            return Ok(res);
        }


        [HttpPut]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand productCommand)
        {
            var res = await _mediator.Send(productCommand);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}",Name ="CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var query=new DeleteProductByIdQuery(id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
