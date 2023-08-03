using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Interfaces
{
    public interface IsalesService
    {
        List<Sales> GetAllVentas();
        Sales GetVentaById(int id);
        Sales CreateVenta(Sales venta);
        Sales UpdateVenta(int id, Sales venta);
        void DeleteVenta(int id);
    }
}