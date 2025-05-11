namespace eHub.Backend.Domain.Models
{
    public class BaseModel
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
