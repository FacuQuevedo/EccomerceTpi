using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Sales CreateVenta(Sales venta)
        {
            _dbContext.Sales.Add(venta);
            _dbContext.SaveChanges();
            return venta;
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