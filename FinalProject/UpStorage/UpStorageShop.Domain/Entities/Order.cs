using UpStorage.Domain.Common;
using UpStorage.Domain.Enum;

namespace UpStorage.Domain.Entities
{
    public class Order: EntityBase
    {
        public int RequestedAmount { get; set; }  //kaç tanesi kazınacak? - kullanıcı sorucak

        public int TotalFoundAmount { get; set; }  // kaç tanesi bulundu yani tümü - crwler sonucu bulunacak değer ilk başta bu dolmayacak-kullanıcıya sorulmayacak

        public ProductCrawlType ProductCrawlType { get; set; }//kazıyacağın ürünlerin tipi - bunu kullanıcı seçecek

        public ICollection<OrderEvent> OrderEvents { get; set; } //BotStarted(kontrol bu)

        public ICollection<Product> Products { get; set; }

    }
}
