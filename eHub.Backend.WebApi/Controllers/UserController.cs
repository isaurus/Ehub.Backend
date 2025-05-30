﻿using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Domain.Models;
using eHub.Backend.WebApi.Controllers.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers
{
    /// <summary>
    /// Controlador para las operaciones CRUD de los usuarios
    /// </summary>
    [ApiController]
    [Route("users")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>Lista completa de usuarios existentes</returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<UserResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserResponseModelListExample))]
        [Produces("application/json")]
        public async Task<ActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();
            return Ok(response);
        }

        /// <summary>
        /// Obtiene un usuario específico por su ID
        /// </summary>
        /// <param name="idUser">El ID único del usuario</param>
        /// <returns>Datos completos del usuario solicitado</returns>
        [HttpGet]
        [Route("{idUser}")]
        [ProducesResponseType(typeof(UserResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserResponseModel))]
        [Produces("application/json")]
        public async Task<ActionResult> GetUserById([FromRoute] int idUser)
        {
            var response = await _userService.GetUserByIdAsync(idUser);
            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="model">El modelo de usuario recibido como request para nueva creación</param>
        /// <returns>Respuesta estándar de éxito</returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(UserModel), typeof(UserModelExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(OkResponseModelExample))]
        [Produces("application/json")]
        public async Task<ActionResult> PostUser([FromBody] UserModel model)
        {
            var response = await _userService.AddUserAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        /// <param name="idUser">El ID único del usuario</param>
        /// <param name="model">El modelo de usuario recibido como request para actualizar</param>
        /// <returns>Respuesta estándar de éxito</returns>
        [HttpPut]
        [Route("{idUser}")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(UserModel), typeof(UserModelExample))]         // ¡NUEVO!
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OkResponseModelExample))]
        [Produces("application/json")]
        public async Task<ActionResult> PutUser([FromRoute] int idUser, [FromBody] UserModel model)
        {
            var response = await _userService.UpdateUserAsync(idUser, model);
            return Ok(response);
        }

        /// <summary>
        /// Elimina un usuario según el ID proporcionado
        /// </summary>
        /// <param name="idUser">El ID único del usuario</param>
        /// <returns>Respuesta estándar de éxito</returns>
        [HttpDelete]
        [Route("{idUser}")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OkResponseModelExample))]
        [Produces("application/json")]
        public async Task<ActionResult> DeleteUser([FromRoute] int idUser)
        {
            var response = await _userService.DeleteUserAsync(idUser);
            return Ok(response);
        }





        

        /// <summary>
        /// Actualiza el usuario creado en la primera fase de registro
        /// </summary>
        /// <param name="idUser">El ID único del usuario</param>
        /// <param name="model">El modelo de usuario recibido como request para actualizar</param>
        /// <returns>Respuesta estándar de éxito</returns>
        [HttpPut]
        [Route("{idUser}/complete-profile")]
        [ProducesResponseType(typeof(OkResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(UserModel), typeof(CompleteUserProfileModel))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OkResponseModelExample))]
        [Produces("application/json")]
        public async Task<ActionResult> CompleteUserProfile([FromRoute] int idUser, [FromBody] CompleteUserProfileModel model)
        {
            var response = await _userService.CompleteUserProfileAsync(idUser, model);
            return Ok(response);
        }

        /*
        /// <summary>
        /// Obtiene el perfil del usuario autenticado
        /// </summary>
        /// <returns>Datos completos del usuario</returns>
        [Authorize]
        [HttpGet("profile")]
        [ProducesResponseType(typeof(UserResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public async Task<ActionResult> GetUserProfile()
        {
            var userIdClaim = User.FindFirst("sub")?.Value;
            if (userIdClaim is null)
                return Unauthorized();

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            var response = await _userService.GetUserByIdAsync(userId);
            return Ok(response);
        }*/

    }
}
