namespace eHub.Backend.Domain.Models
{
    /// <summary>
    /// Modelo de respuesta para las acciones que hayan modificado la DB (Commands).
    /// </summary>
    public class OkResponseModel : BaseModel
    {

        /// <summary>
        /// El ID del recurso creado/actualizado.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// El mensaje operativo sobre el tipo de operación recién efectuada.
        /// </summary>
        public string Message { get; set; } = null!;
    }
}
