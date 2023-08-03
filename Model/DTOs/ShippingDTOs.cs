using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ShippingDTOs
    {
        public int IdShipping { get; set; }
        public string Destination { get; set; }
        public string StateEnvio { get; set; }
        public int IdProduct { get; set; }
        public int IdSales { get; set; }

    }
}
