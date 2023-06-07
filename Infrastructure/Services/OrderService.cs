using Core.Interfaces;
using Core.Models;
using Core.Models.OrderAggregate;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IBasketRepository _basketRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<DeliveryMethod> _deliveryRepo;

        public OrderService(IGenericRepository<Order> orderRepo, IBasketRepository basketRepo, 
            IGenericRepository<Product> productRepo,
            IGenericRepository<DeliveryMethod> deliveryRepo)
        {
            _orderRepo = orderRepo;
            _basketRepo = basketRepo;
            _productRepo = productRepo;
            _deliveryRepo = deliveryRepo;
        }
        
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);
            var items = new List<OrderItem>();
            foreach(var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                //Take product repo price instead of price taken from client basket
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _deliveryRepo.GetByIdAsync(deliveryMethodId);
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
