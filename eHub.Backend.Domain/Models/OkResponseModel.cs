namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de datos de respuesta para operaciones de modificación de DB
    /// </summary>
    public class OkResponseModel : BaseModel
    {
        public int Id { get; set; }

        public string Message { get; set; } = null!;
    }
}
