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
        ProductsDTOs CreateProducto(Products producto);
        ProductsDTOs UpdateProducto(int id, Products producto);
        void DeleteProducto(int id);
    }
}