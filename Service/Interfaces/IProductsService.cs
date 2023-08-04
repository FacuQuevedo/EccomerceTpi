using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;
using Model.Models;

namespace Service.Interfaces
{
    public interface IProductsService
    {
        List<ProductsDTOs> GetAllProductos();
        ProductsDTOs GetProductoById(int id);
        ProductsDTOs CreateProducto(ProductsDTOs producto);
        ProductsDTOs UpdateProducto(ProductsDTOs producto);
        void DeleteProducto(int id);
    }
}