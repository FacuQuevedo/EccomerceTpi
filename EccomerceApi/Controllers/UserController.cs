using Eccomerce.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service.Interfaces;
using Service.Inmplementations;
using System.Security.Claims;
namespace Eccomerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {

        private readonly IUserService _userSerivice;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService adminService, ILogger<UserController> logger)
        {
            _userSerivice = adminService;
            _logger = logger;
        }

        [HttpGet("getUserById/{id}")]
        public ActionResult<UserDTO> getUserById([FromRoute] int id)
        {

            try
            {
                var response = _userSerivice.GetUserById(id);
                if (response == null)
                {
                    return NotFound($"No se encontro el usuario con id {id}");
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogCustomError("getUserByID", ex);
                return BadRequest($"{ex.Message}");
            }

        }


        [Authorize(policy: "SuperAdminAndAdmin")]

        [HttpGet("getAll")]
        public ActionResult<List<UserDTO>> getAll()
        {

            try
            {
                var response = _userSerivice.GetAll();
                if (response.Count == 0)
                {
                    return NotFound("No hay Usuarios");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("GetEmpleadoById", ex);
                return BadRequest($"{ex.Message}");
            }

        }
        [HttpDelete("DeleteUsers/{id}")]
        public ActionResult DeleteUsers(int id)
        {
            try
            {
                _userSerivice.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("UpdateUser")]
        public ActionResult UpdateUser([FromBody] CreateUser user)
        {
            try
            {
                var response = _userSerivice.UpdateUser(user);

                string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                string apiAndEndpointUrl = $"api/Empleado/GetUserById";
                string locationUrl = $"{baseUrl}/{apiAndEndpointUrl}/{response.IdUser}";
                return Created(locationUrl, response);
            }
            catch (Exception ex)
            {
                _logger.LogCustomError("UpdateEmpleado", ex);
                return BadRequest($"{ex.Message}");
            }
        }

    }
}


