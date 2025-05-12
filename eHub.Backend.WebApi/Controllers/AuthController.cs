using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Domain.Models;
using eHub.Backend.WebApi.Controllers.Swagger;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers
{
    /// <summary>
    /// Controlador para las operaciones de Autenticación y Registro
    /// </summary>
    [ApiController]
    [Route("auth")]
    public class AuthController(IUserService userService, IAuthService authService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// Registra un nuevo usuario
        /// </summary>
        /// <param name="model">El modelo de registro de usuario recibido como request</param>
        /// <returns>Respuesta estándar de éxito</returns>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(UserModel), typeof(RegisterUserModelExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(OkResponseModelExample))]
        [Produces("application/json")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserModel model)
        {
            var response = await _userService.RegisterUserAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Logea un usuario existente
        /// </summary>
        /// <param name="model">El modelo de login de usuario recibido como request</param>
        /// <returns>Respuesta estándar de éxito</returns>
        [HttpPost]
        [Route("{idUser}/login")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(UserModel), typeof(RegisterUserModelExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(OkResponseModelExample))]
        [Produces("application/json")]
        public async Task<ActionResult> LoginUser([FromRoute] int idUser, [FromBody] LoginUserModel model)
        {
            var response = await _userService.LoginUserAsync(idUser, model);
            return Ok(response);
        }
    }
}
