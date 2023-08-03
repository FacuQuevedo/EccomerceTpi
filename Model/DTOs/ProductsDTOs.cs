using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ProductsDTOs
    {
        public object Descripcion;

        public int IdProduct { get; set; }
        public string Product { get; set; }
        public string Descriptions { get; set; }
        public decimal Price { get; set; }
    }
}
