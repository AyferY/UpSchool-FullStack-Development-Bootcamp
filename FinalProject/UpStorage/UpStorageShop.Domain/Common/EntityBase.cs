namespace UpStorage.Domain.Common
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
