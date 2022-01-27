using checkout_kata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout_kata.Interfaces
{
    public interface IDiscounter
    {
        double CalculateDiscount(IEnumerable<Product> products);
    }
}
