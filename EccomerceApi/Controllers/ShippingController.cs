using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Models;
using Service.Interfaces;

namespace Eccomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ShippingController : ControllerBase
    {
        private readonly IShippingService _enviosService;

        public ShippingController(IShippingService enviosService)
        {
            _enviosService = enviosService;
        }

        // GET: api/Envios
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var envios = _enviosService.GetAllEnvios();
                return Ok(envios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener los envíos: {ex.Message}");
            }
        }

        // GET: api/Envios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var envio = _enviosService.GetEnvioById(id);
                if (envio == null)
                {
                    return NotFound();
                }
                return Ok(envio);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener el envío: {ex.Message}");
            }
        }

        // POST: api/Envios
        [HttpPost]
        public IActionResult Post([FromBody] ShippingDTOs envio)
        {
            try
            {
                var nuevoEnvio = _enviosService.CreateEnvio(envio);
                return CreatedAtAction(nameof(Get), new { id = nuevoEnvio.IdShipping }, nuevoEnvio);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el envío: {ex.Message}");
            }
        }

        // PUT: api/Envios/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShippingDTOs envio)
        {
            try
            {
                var updatedEnvio = _enviosService.UpdateEnvio(id, envio);
                if (updatedEnvio == null)
                {
                    return NotFound();
                }
                return Ok(updatedEnvio);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el envío: {ex.Message}");
            }
        }

        // DELETE: api/Envios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _enviosService.DeleteEnvio(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el envío: {ex.Message}");
            }
        }
    }
}