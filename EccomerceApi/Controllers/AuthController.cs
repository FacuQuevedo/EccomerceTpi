using Service.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.ViewModels;
using Service.Inmplementations;
using Service.Interfaces;
namespace Eccomerce.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService service, ILogger<AuthController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("Login")]
        public ActionResult<string> Login([FromBody] AuthDTO User)
        {
            string response = string.Empty;
            try
            {
                response = _service.Login(User);
                if (string.IsNullOrEmpty(response))
                    return NotFound("email/contraseña incorrecta");
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("Login", ex);
                return BadRequest($"{ex.Message}");
            }

            return Ok(response);
        }

        [HttpPost("CrearUsuario")]
        public ActionResult<string> CrearUsuario([FromBody] UserViewModel User)
        {
            string response = string.Empty;
            try
            {
                response = _service.CrearUsuario(User);
                if (response == "Ingrese un usuario" || response == "Usuario existente")
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("CrearUsuario", ex);
                // Mostrar el mensaje de la excepción
                Console.WriteLine("Mensaje de la excepción: " + ex.Message);

                // Mostrar la pila de llamadas (Trace)
                Console.WriteLine("Trace de la excepción: " + ex.StackTrace);

                // También puedes acceder a la excepción interna (inner exception) si la hay
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Mensaje de la excepción interna: " + ex.InnerException.Message);
                    Console.WriteLine("Trace de la excepción interna: " + ex.InnerException.StackTrace);
                }
                return BadRequest($"{ex.Message}");

            }

            return Ok(response);
        }
    }

}

