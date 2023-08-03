using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Model.Models;
using Service.Interfaces;

namespace Eccomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var productos = _productosService.GetAllProductos();
            return Ok(productos);
        }

        // GET: api/Productos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var producto = _productosService.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        // POST: api/Productos
        [HttpPost]
        public IActionResult Post([FromBody] ProductsDTOs producto)
        {
            var nuevoProducto = _productosService.CreateProducto(producto);
            return CreatedAtAction(nameof(Get), new { id = nuevoProducto.IdProduct }, nuevoProducto);
        }

        // PUT: api/Productos/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Products producto)
        {
            var updatedProducto = _productosService.UpdateProducto(id, producto);
            if (updatedProducto == null)
            {
                return NotFound();
            }
            return Ok(updatedProducto);
        }

        // DELETE: api/Productos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productosService.DeleteProducto(id);
            return Ok();
        }
    }
}