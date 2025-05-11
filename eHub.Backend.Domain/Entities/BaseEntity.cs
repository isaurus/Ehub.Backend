namespace eHub.Backend.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DeletedTimeUtc { get; set; }
    }
}
