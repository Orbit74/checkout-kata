namespace checkout_kata.Interfaces
{
    public interface ICheckout
    {
        void Scan(string sku, int quantity);
        double SubTotal { get; }
        double TotalWithOffers { get; }
    }
}
