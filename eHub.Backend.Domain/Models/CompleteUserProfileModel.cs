using eHub.Backend.Domain.Enums;

namespace eHub.Backend.Domain.Models
{
    public class CompleteUserProfileModel
    {
        /// <summary>
        /// El avatar seleccionado por el usuario en la segunda fase de regsitro (requerido).
        /// </summary>
        public required string ProfilePicUrl { get; set; }

        /// <summary>
        /// Nombre del usuario en la segunda fase de regsitro (requerido) (Máx. 50 caracteres).
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Apellido del usuario en la segunda fase de regsitro (requerido) (Máx. 255 caracteres).
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Fecha de nacimiento del usuario en la segunda fase de regsitro (requerido).
        /// </summary>
        public required DateOnly BirthDate { get; set; }

        /// <summary>
        /// Nacionalidad del usuario en la segunda fase de regsitro (requerido).
        /// </summary>
        public required Country Country { get; set; }
    }
}
