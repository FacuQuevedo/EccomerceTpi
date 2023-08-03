using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Service.Interfaces;

namespace Service.Inmplementations
{
    public class VariantService : IVariantService
    {
        private readonly ecommerceDBContext _dbContext;

        public VariantService(ecommerceDBContext dbContext  )
        {
            _dbContext = dbContext;
        }

        public List<Variant> GetAllVariantes()
        {
            return _dbContext.Variant.ToList();
        }

        public Variant GetVarianteById(int id)
        {
            return _dbContext.Variant.Find(id);
        }

        public Variant CreateVariante(Variant variante)
        {
            _dbContext.Variant.Add(variante);
            _dbContext.SaveChanges();
            return variante;
        }

        public Variant UpdateVariante(int id, Variant variante)
        {
            var existingVariante = _dbContext.Variant.Find(id);
            if (existingVariante != null)
            {
                existingVariante.Color = variante.Color;
                existingVariante.Descriptions = variante.Descriptions;
                _dbContext.SaveChanges();
            }
            return existingVariante;
        }

        public void DeleteVariante(int id)
        {
            var variante = _dbContext.Variant.Find(id);
            if (variante != null)
            {
                _dbContext.Variant.Remove(variante);
                _dbContext.SaveChanges();
            }
        }
    }
}