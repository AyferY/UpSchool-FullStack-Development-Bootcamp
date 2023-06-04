using UpStorage.Domain.Enum;

namespace UpStorage.Domain.Dtos
{
    public class UpStorageOrderEventDto
    {
        public Guid OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public UpStorageOrderEventDto(Guid orderId, OrderStatus status)
        {
            OrderId = orderId;
            Status = status;
        }
    }
}
