using Core.Models;

namespace Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        void Update(Product product);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetProductByNameAsync(string name);
        void DeleteByIdAsync(int id);
    }
}
