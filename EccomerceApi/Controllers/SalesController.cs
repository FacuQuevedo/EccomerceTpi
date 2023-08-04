using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Models;
using Service.Inmplementations;
using Service.Interfaces;

namespace Eccomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SalesController : ControllerBase
    {
        private readonly IsalesService _ventasService;

        public SalesController(IsalesService ventasService)
        {
            _ventasService = ventasService;
        }

        // GET: api/Ventas
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var ventas = _ventasService.GetAllVentas();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener las ventas: {ex.Message}");
            }
        }

        // GET: api/Ventas/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var venta = _ventasService.GetVentaById(id);
                if (venta == null)
                {
                    return NotFound();
                }
                return Ok(venta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener la venta: {ex.Message}");
            }
        }

        // POST: api/Ventas
        [HttpPost]
        public IActionResult Post([FromBody] SalesDTOs venta)
        {
            try
            {
                var nuevaVenta = _ventasService.CreateVenta(venta);
                return CreatedAtAction(nameof(Get), new { id = nuevaVenta.IdSales }, nuevaVenta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la venta: {ex.Message}");
            }
        }

        //// PUT: api/Ventas/{id}
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Sales venta)
        //{
        //    try
        //    {
        //        var updatedVenta = _ventasService.UpdateVenta(id, venta);
        //        if (updatedVenta == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(updatedVenta);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error al actualizar la venta: {ex.Message}");
        //    }
        //}

        // DELETE: api/Ventas/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ventasService.DeleteVenta(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la venta: {ex.Message}");
            }
        }
    }
}