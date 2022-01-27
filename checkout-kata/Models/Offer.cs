using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata.Models
{
    public class Offer
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
    }
}
