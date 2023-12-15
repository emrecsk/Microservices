using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order(string buyerId, Address address)
        {
            _orderItems = new();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }
        public Order()
        {
           
        }
        public void AddOrderItem(string productId, string productName, decimal price, string pictureURL)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, price, pictureURL);
                _orderItems.Add(newOrderItem);
            }
        }
        public void UpdateOrderItem(string productId, string productName, decimal price, string pictureURL)
        {
            var existProduct = _orderItems.FirstOrDefault(x => x.ProductId == productId);
            if (existProduct != null)
            {
                existProduct.UpdateOrderItem(productName, price, pictureURL);
            }
        }
        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }    
}
