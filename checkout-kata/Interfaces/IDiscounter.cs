using checkout_kata.Models;

namespace checkout_kata.Interfaces
{
    public interface IDiscounter
    {
        /// <summary>
        /// Calculates the total discount for the input products.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        decimal CalculateDiscount(IEnumerable<Product> products);
    }
}
