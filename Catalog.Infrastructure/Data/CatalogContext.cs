using Catalog.Core.Entities;
using Catalog.Infrastructure.Data.SeedData;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductType> Types { get; }

        public IMongoCollection<ProductBrand> Brands { get; }
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSeetings:ConnectionString"));
            var db = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
           
            Brands = db.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabseSettings:BrandsCollection"));
            Types = db.GetCollection<ProductType>(configuration.GetValue<string>("DatabseSettings:TypesCollection"));
            Products = db.GetCollection<Product>(configuration.GetValue<string>("DatabseSettings:ProductsCollection"));

            BrandContextSeed.SeedData(Brands);
            TypeContextSeed.SeedData(Types);
            CatalogContextSeed.SeedData(Products);
       
        }
      
    }
}
