using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;
using Model.Models;

namespace Service.Interfaces
{
    public interface IsalesService
    {
        List<SaleResponseDTO> GetAllVentas();
        Sales GetVentaById(int id);
        SalesDTOs CreateVenta(SalesDTOs venta);
        Sales UpdateVenta(int id, Sales venta);
        void DeleteVenta(int id);
    }
}