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
    public class ProductosController : ControllerBase
    {
        private readonly IProductsService _productosService;
        private readonly ecommerceDBContext _dbContext;

        public ProductosController(IProductsService productosService, ecommerceDBContext dbContext)
        {
            _productosService = productosService;
            _dbContext = dbContext;
        }

        // GET: api/Productos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var productos = _productosService.GetAllProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener los productos: {ex.Message}");
            }
        }

        // GET: api/Productos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var producto = _productosService.GetProductoById(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener el producto: {ex.Message}");
            }
        }

        // POST: api/Productos
        [HttpPost]
        public IActionResult Post([FromBody] ProductsDTOs producto)
        {
            try
            {
                var nuevoProducto = _productosService.CreateProducto(producto);
                return CreatedAtAction(nameof(Get), new { id = nuevoProducto.IdProduct }, nuevoProducto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el producto: {ex.Message}");
            }
        }

        // PUT: api/Productos/{id}
        [HttpPut("UpdateProduct")]
        public IActionResult Put([FromBody] ProductsDTOs producto)
        {
            try
            {
                var updatedProducto = _productosService.UpdateProducto(producto);
                if (updatedProducto == null)
                {
                    return NotFound();
                }
                return Ok(updatedProducto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el producto: {ex.Message}");
            }
        }

        // DELETE: api/Productos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productosService.DeleteProducto(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el producto: {ex.Message}");
            }
        }
    }
}