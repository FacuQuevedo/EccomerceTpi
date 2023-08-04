using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class SaleResponseDTO
    {

        public int IdSales { get; set; }
        public DateTime DateSale { get; set; }
        public int IdUser { get; set; }
        public int IdShipping { get; set; }
        public string Destination { get; set; }
        public string StateEnvio { get; set; }
        public List<ShippingProductDTO> products { get; set; }

    }
}
