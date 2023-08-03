using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Model.Models;
using Service.Interfaces;

namespace Service.Inmplementations
{
    public class SalesService : IsalesService
    {
        private readonly ecommerceDBContext _dbContext;

        public SalesService(ecommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Sales> GetAllVentas()
        {
            return _dbContext.Sales.ToList();
        }

        public Sales GetVentaById(int id)
        {
            return _dbContext.Sales.Find(id);
        }

        public SalesDTOs CreateVenta(SalesDTOs sale)
        {
            Sales newSale = new Sales()
            {
                IdSales = sale.IdSales,
                DateSale = sale.DateSale,
                IdUser = sale.IdUser,
            };
            _dbContext.Sales.Add(newSale);
            _dbContext.SaveChanges();

            Shipping shipping = new Shipping()
            {

                Destination = sale.ShippingDestination,
                StateEnvio = "pendiente",
                IdSales = newSale.IdSales,
            };

            _dbContext.Shipping.Add(shipping);
            _dbContext.SaveChanges();

            // Recorremos la lista de productos y los agregamos a la base de datos
            foreach (var product in sale.productos)
            {
                // Creamos un nuevo objeto Shipping para cada producto
                ShippingProducts shippingproducts = new ShippingProducts()
                {
                    IdProduct = product.IdProduct,
                    IdShipping = shipping.IdShipping,
                };

                // Aquí asumimos que el objeto "product" tiene una propiedad "IdProduct" que corresponde al IdProduct en la tabla Shipping.
                // Asignamos el IdProduct correspondiente al objeto "Shipping".

                // Agregamos el objeto "Shipping" al DbContext
                _dbContext.ShippingProducts.Add(shippingproducts);
            }


            _dbContext.SaveChanges();
            return sale;
        }

        public Sales UpdateVenta(int id, Sales venta)
        {
            var existingVenta = _dbContext.Sales.Find(id);
            if (existingVenta != null)
            {
                existingVenta.DateSale = venta.DateSale;
                existingVenta.IdUser = venta.IdUser;
                _dbContext.SaveChanges();
            }
            return existingVenta;
        }

        public void DeleteVenta(int id)
        {
            var venta = _dbContext.Sales.Find(id);
            if (venta != null)
            {
                _dbContext.Sales.Remove(venta);
                _dbContext.SaveChanges();
            }
        }
    }
}