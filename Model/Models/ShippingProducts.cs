﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ShippingProducts
    {
        public int IdShippingProducts { get; set; }
        public int? IdProduct { get; set; }
        public int IdShipping { get; set; }

        public virtual Products IdProductNavigation { get; set; }
        public virtual Shipping IdShippingNavigation { get; set; }
    }
}