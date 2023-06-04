using UpStorage.Domain.Common;
using UpStorage.Domain.Enum;

namespace UpStorage.Domain.Dtos
{
    public class UpStorageOrderDto: EntityBase
    {
        public int RequestedAmount { get; set; }
        public int TotalFoundAmount { get; set; }
        public ProductCrawlType ProductCrawlType { get; set; }

        public UpStorageOrderDto(Guid id, DateTimeOffset createdOn, int requestedAmount, int totalFoundAmount, ProductCrawlType productCrawlType)
        {
            Id = id;
            CreatedOn = createdOn;
            RequestedAmount = requestedAmount;
            TotalFoundAmount = totalFoundAmount;
            ProductCrawlType = productCrawlType;
        }
    }
}
