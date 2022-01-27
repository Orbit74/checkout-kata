namespace checkout_kata.Models
{
    public class Order
    {
        public IList<Product> Items { get; set; } = new List<Product>();
        public double TotalDiscount { get; set; }
        public double SubTotal => Items.Sum(x => x.UnitPrice);
        public double Total => SubTotal - TotalDiscount;
    }
}
