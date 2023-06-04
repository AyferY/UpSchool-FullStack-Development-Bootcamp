using UpStorage.Domain.Common;
using UpStorage.Domain.Enum;

namespace UpStorage.Domain.Entities
{
    public class OrderEvent : EntityBase
    {
        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public OrderStatus Status { get; set; }

    }
}
