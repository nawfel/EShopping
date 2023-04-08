﻿using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.SeedData
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkproduct = productCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!checkproduct)
            {
                var productsData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products != null)
                {
                    foreach (var brand in products)
                    {
                        productCollection.InsertOneAsync(brand);
                    }
                }
            }
        }
    }
}
