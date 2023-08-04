using System.Collections.Generic;
using System.Linq;
using Model.DTOs;
using Model.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;

namespace Service.Inmplementations
{
    public class ProductsService : IProductsService
    {
        private readonly ecommerceDBContext _dbContext;

        public ProductsService(ecommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductsDTOs> GetAllProductos()
        {
            return _dbContext.Products
                .Select(p => new ProductsDTOs
                {
                    IdProduct = p.IdProduct,
                    Product = p.Product,
                    Descriptions = p.Descriptions,
                    Price = p.Price
                })
                .ToList();
        }

        public ProductsDTOs GetProductoById(int id)
        {
            return _dbContext.Products
                .Where(p => p.IdProduct == id)
                .Select(p => new ProductsDTOs
                {
                    IdProduct = p.IdProduct,
                    Product = p.Product,
                    Descriptions = p.Descriptions,
                    Price = p.Price
                })
                .FirstOrDefault();
        }


        public void DeleteProducto(int id)
        {
            Products producto = _dbContext.Products.Find(id);
            if (producto != null)
            {
                _dbContext.Products.Remove(producto);
                _dbContext.SaveChanges();
            }
        }

        public ProductsDTOs CreateProducto(ProductsDTOs producto)
        {
            Products newProduct = new Products()
            {
                IdProduct = producto.IdProduct,
                Product = producto.Product,
                Descriptions = producto.Descriptions,
                Price = producto.Price
            };
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            return new ProductsDTOs
            {
                IdProduct = producto.IdProduct,
                Product = producto.Product,
                Descriptions = producto.Descriptions,
                Price = producto.Price
            };
        }

        public ProductsDTOs UpdateProducto(ProductsDTOs producto)
        {
            Products existingProducto = _dbContext.Products.Find(producto.IdProduct);
            if (existingProducto != null)
            {
                existingProducto.Product = producto.Product;
                existingProducto.Descriptions = producto.Descriptions;
                existingProducto.Price = producto.Price;
                _dbContext.SaveChanges();
            }
            return new ProductsDTOs
            {
                IdProduct = existingProducto.IdProduct,
                Product = existingProducto.Product,
                Descriptions = existingProducto.Descriptions,
                Price = existingProducto.Price
            };
        }
    }
}