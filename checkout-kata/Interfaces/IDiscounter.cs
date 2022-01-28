using checkout_kata.Models;

namespace checkout_kata.Interfaces
{
    public interface IDiscounter
    {
        double CalculateDiscount(IEnumerable<Product> products);
    }
}
