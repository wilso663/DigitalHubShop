using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(StoreContext context, IMapper mapper) 
        { 
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return null;

            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
