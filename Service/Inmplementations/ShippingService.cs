using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.DTOs;
using Model.Models;
using Service.Interfaces;

namespace Service.Inmplementations
{
    public class ShippingService : IShippingService
    {
        private readonly ecommerceDBContext _dbContext;

        public ShippingService(ecommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ShippingDTOs> GetAllEnvios()
        {
            return _dbContext.Shipping.Select(envio => new ShippingDTOs
            {
                IdShipping = envio.IdShipping,
                Destination = envio.Destination,
                StateEnvio = envio.StateEnvio,
            }).ToList();
        }

        public ShippingDTOs GetEnvioById(int id)
        {
            var envio = _dbContext.Shipping.Find(id);
            if (envio != null)
            {
                return new ShippingDTOs
                {
                    IdShipping = envio.IdShipping,
                    Destination = envio.Destination,
                    StateEnvio = envio.StateEnvio,
                };
            }
            return null;
        }

        public ShippingDTOs CreateEnvio(ShippingDTOs envio)
        {
            var newEnvio = new Shipping()
            {
                
                Destination = envio.Destination,
                StateEnvio = envio.StateEnvio,
            };

            _dbContext.Shipping.Add(newEnvio);
            _dbContext.SaveChanges();

            envio.IdShipping = newEnvio.IdShipping;
            return envio;
        }

        public ShippingDTOs UpdateEnvio(int id, ShippingDTOs envio)
        {
            var existingEnvio = _dbContext.Shipping.Find(id);
            if (existingEnvio != null)
            {
                existingEnvio.Destination = envio.Destination;
                existingEnvio.StateEnvio = envio.StateEnvio;
                _dbContext.SaveChanges();
           
                return new ShippingDTOs
                {
                    IdShipping = envio.IdShipping,
                    Destination = envio.Destination,
                    StateEnvio = envio.StateEnvio,
                 
                };
            }
            return null;
        }

        public void DeleteEnvio(int id)
        {
            var envio = _dbContext.Shipping.Find(id);
            if (envio != null)
            {
                _dbContext.Shipping.Remove(envio);
                _dbContext.SaveChanges();
            }
        }
    }
}