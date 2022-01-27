using checkout_kata.Models;

namespace checkout_kata.Interfaces
{
    public interface IOfferCatalogue
    {
        IEnumerable<Offer> Get();

        Offer? Get(string sku);
    }
}
