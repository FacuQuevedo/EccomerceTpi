using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;

namespace Service.Interfaces

{
    public interface IShippingService
    {
        List<ShippingDTOs> GetAllEnvios();
        ShippingDTOs GetEnvioById(int id);
        ShippingDTOs CreateEnvio(ShippingDTOs envio);
        ShippingDTOs UpdateEnvio(int id, ShippingDTOs envio);
        public void DeleteEnvio(int id);
    }
}