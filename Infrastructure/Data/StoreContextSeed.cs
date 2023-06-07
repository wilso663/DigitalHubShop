using Core.Models;
using Core.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            //To turn identity insert allow for microsoft sql, use this command and then set it back to off when complete
            // await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [DigitalHubShopDB].[dbo].[Orders] ON;");
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData); 
                context.Products.AddRange(products);
            }
            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }
            if (!context.DeliveryMethods.Any())
            {

                var deliveriesData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                var deliveries = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveriesData);
                context.DeliveryMethods.AddRange(deliveries);
            }
            if (context.ChangeTracker.HasChanges()) {
                await context.SaveChangesAsync();
            }
        }
    }
}
