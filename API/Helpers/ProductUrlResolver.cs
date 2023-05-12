using API.DTOs;
using AutoMapper;
using Core.Models;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductReturnDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(Microsoft.Extensions.Configuration.IConfiguration config) 
        {
            this._config = config;
        }
        public string Resolve(Product source, ProductReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
