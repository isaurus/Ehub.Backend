namespace eHub.Backend.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; set; } = default!;
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedTimeUtc { get; set; }
    }
}
