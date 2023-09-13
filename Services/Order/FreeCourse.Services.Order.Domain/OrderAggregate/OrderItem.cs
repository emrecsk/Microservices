using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public string PictureURL { get; private set; }

        public OrderItem()
        {
        }

        public OrderItem(string productId, string productName, decimal price, string pictureURL)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            PictureURL = pictureURL;
        }
        public void UpdateOrderItem(string productName, decimal price, string pictureURL)
        {
            ProductName = productName;
            Price = price;
            PictureURL = pictureURL;
        }
    }
}
