using UpStorage.Domain.Enum;

namespace UpStorage.Domain.Dtos
{
    public class UpStorageLogDto
    {
        public string Message { get; set; }
        public DateTimeOffset SentOn { get; set; }

        public OrderStatus orderStatus { get; set; }

        public UpStorageLogDto(string message)
        {
            Message = message;
            //orderStatus = status;
            SentOn = DateTimeOffset.Now;
        }
    }
}
