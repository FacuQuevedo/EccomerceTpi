using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Models;
using Service.Inmplementations;
using Service.Interfaces;

namespace Eccomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var ventas = _ventasService.GetAllVentas();
            return Ok(ventas);
        }

        // GET: api/Ventas/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var venta = _ventasService.GetVentaById(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        // POST: api/Ventas
        [HttpPost]
        public IActionResult Post([FromBody] SalesDTOs venta)
        {
            var nuevaVenta = _ventasService.CreateVenta(venta);
            return CreatedAtAction(nameof(Get), new { id = nuevaVenta.IdSales }, nuevaVenta);
        }

        // PUT: api/Ventas/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Sales venta)
        {
            var updatedVenta = _ventasService.UpdateVenta(id, venta);
            if (updatedVenta == null)
            {
                return NotFound();
            }
            return Ok(updatedVenta);
        }

        // DELETE: api/Ventas/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ventasService.DeleteVenta(id);
            return Ok();
        }
    }
}