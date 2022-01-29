namespace checkout_kata.Models
{
    public class Order
    {
        public List<Product> Items { get; set; } = new List<Product>();
        public decimal TotalDiscount { get; set; }
        public decimal SubTotal => Items.Sum(x => x.UnitPrice);
        public decimal Total => SubTotal - TotalDiscount;
    }
}
