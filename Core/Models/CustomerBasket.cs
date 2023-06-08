﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items {get; set; } = new List<BasketItem>();
        public int? DeliveryMethodId { get; set; }
        public string CilentSecret { get; set; }
        public string PaymentIntentId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingPrice { get; set; }
        
    }
}
