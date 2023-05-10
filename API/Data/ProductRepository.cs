using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(DataContext context, IMapper mapper) 
        { 
            this._context = context;
            this._mapper = mapper;
        }
        void IProductRepository.DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.id == id);
            if (product == null)
                return null;

            return product;
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await _context.Products
                .Where(x => x.name == name)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        void IProductRepository.Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
