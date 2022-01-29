namespace checkout_kata.Interfaces
{
    public interface ICheckout
    {
        /// <summary>
        /// Adds products to the checkout total.
        /// </summary>
        /// <param name="sku">Identifier for the product</param>
        /// <param name="quantity">Number of items</param>
        void Scan(string sku, int quantity);

        /// <summary>
        /// The total price of scanned items before any discount offers have been applied.
        /// </summary>
        decimal SubTotal { get; }

        /// <summary>
        /// The total price of scanned items after all discount offers have been applied.
        /// </summary>
        decimal TotalWithOffers { get; }
    }
}
