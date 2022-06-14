using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }
    }
}
