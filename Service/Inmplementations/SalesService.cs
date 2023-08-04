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


        public List<SaleResponseDTO> GetAllVentas()
        {
            List<Sales> sales = _dbContext.Sales.ToList();
            List<Shipping> shippings = _dbContext.Shipping.ToList();
            List<ShippingProducts> shippingProducts = _dbContext.ShippingProducts.ToList();

            List<SaleResponseDTO> request = new List<SaleResponseDTO>();

            foreach (Sales sale in sales)
            {
                // Buscar el envío correspondiente a la venta actual
                Shipping shipping = shippings.FirstOrDefault(s => s.IdShipping == sale.IdShipping);

                if (shipping != null)
                {
                    // Buscar los productos asociados al envío
                    List<ShippingProducts> products = shippingProducts.Where(sp => sp.IdShipping == sale.IdShipping).ToList();

                    // Crear una lista de ShippingProductDTO a partir de la lista filtrada products
                    List<ShippingProductDTO> productsdto = products.Select(sp => new ShippingProductDTO
                    {
                        IdProduct = sp.IdProduct,
                        IdShipping = sp.IdShipping
                    }).ToList();
                    // Crear el objeto SaleResponseDTO
                    SaleResponseDTO saleResponse = new SaleResponseDTO
                    {
                        IdSales = sale.IdSales,
                        DateSale = sale.DateSale,
                        IdUser = sale.IdUser,
                        IdShipping = sale.IdShipping,
                        Destination = shipping.Destination,
                        StateEnvio = shipping.StateEnvio,
                        products = productsdto,
                    };

                    request.Add(saleResponse);
                }
            }

            return request;
        }


        public SaleResponseDTO GetVentaById(int idVenta)
        {
            Sales sale = _dbContext.Sales.FirstOrDefault(s => s.IdSales == idVenta);

            if (sale == null)
            {
                return null; // Venta no encontrada, puedes manejar esto según tus necesidades
            }

            Shipping shipping = _dbContext.Shipping.FirstOrDefault(s => s.IdShipping == sale.IdShipping);

            if (shipping == null)
            {
                return null; // Envío no encontrado, puedes manejar esto según tus necesidades
            }

            List<ShippingProducts> shippingProducts = _dbContext.ShippingProducts
                .Where(sp => sp.IdShipping == sale.IdShipping)
                .ToList();

            List<ShippingProductDTO> productsdto = shippingProducts.Select(sp => new ShippingProductDTO
            {
                IdProduct = sp.IdProduct,
                IdShipping = sp.IdShipping
            }).ToList();

            SaleResponseDTO saleResponse = new SaleResponseDTO
            {
                IdSales = sale.IdSales,
                DateSale = sale.DateSale,
                IdUser = sale.IdUser,
                IdShipping = sale.IdShipping,
                Destination = shipping.Destination,
                StateEnvio = shipping.StateEnvio,
                products = productsdto,
            };

            return saleResponse;
        }



        public SalesDTOs CreateVenta(SalesDTOs sale)
        {
            Shipping shipping = new Shipping()
            {

                Destination = sale.ShippingDestination,
                StateEnvio = "pendiente",
            };

            _dbContext.Shipping.Add(shipping);
            _dbContext.SaveChanges();


            Sales newSale = new Sales()
            {
                IdSales = sale.IdSales,
                DateSale = sale.DateSale,
                IdUser = sale.IdUser,
                IdShipping = shipping.IdShipping
            };
            _dbContext.Sales.Add(newSale);
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

        //public Sales UpdateVenta(int id, Sales venta)
        //{
        //    var existingVenta = _dbContext.Sales.Find(id);
        //    if (existingVenta != null)
        //    {
        //        existingVenta.DateSale = venta.DateSale;
        //        existingVenta.IdUser = venta.IdUser;
        //        _dbContext.SaveChanges();
        //    }
        //    return existingVenta;
        //}

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