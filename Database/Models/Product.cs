using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Models
{
    public class Product : Entity
    {
        public string NameProduct { get; set; }
        public int PriceProduct { get; set; }
    }
}
