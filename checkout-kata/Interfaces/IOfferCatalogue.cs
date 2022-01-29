using checkout_kata.Models;

namespace checkout_kata.Interfaces
{
    public interface IOfferCatalogue
    {
        /// <summary>
        /// Get all available offers in the catalogue.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Offer> Get();

        /// <summary>
        /// Get a single offer from the catalogue.
        /// </summary>
        /// <param name="sku">Offer identifier</param>
        /// <returns>Offer or null</returns>
        Offer? Get(string sku);
    }
}
