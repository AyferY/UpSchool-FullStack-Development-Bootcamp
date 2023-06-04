using UpStorage.Domain.Common;
using UpStorage.Domain.Entities;

namespace UpStorage.Domain.Dtos
{
    public class UpStorageProductDto: EntityBase
    {
        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public bool IsOnSale { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public UpStorageProductDto(Guid id,Guid orderId, DateTimeOffset createdOn, string name, string picture, bool isOnSale, decimal price, decimal salePrice)
        {
            OrderId = orderId;
            Id = id;
            CreatedOn = createdOn;
            Name = name;
            Picture = picture;
            IsOnSale = isOnSale;
            Price = price;
            SalePrice = salePrice;
        }
    }
}