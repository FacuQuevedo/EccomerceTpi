using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class SalesDTOs
    {
        public int IdSales { get; set; }
        public DateTime DateSale { get; set; }
        public int IdUser { get; set; }

        public string ShippingDestination { get; set; }

        public List<ProductsDTOs> productos { get; set; }

    }
}
