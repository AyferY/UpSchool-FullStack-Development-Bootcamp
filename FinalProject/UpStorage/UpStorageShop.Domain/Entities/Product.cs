using UpStorage.Domain.Common;
namespace UpStorage.Domain.Entities
{
    public class Product : EntityBase
    {

        public Guid OrderId { get; set; }

        public Order? Order { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public bool IsOnSale { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
