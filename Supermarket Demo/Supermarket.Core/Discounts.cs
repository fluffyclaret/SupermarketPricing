namespace Supermarket.Core
{
    public class Discounts
    {
        public Discounts()
        {
              discounts = new Discount[0];  
        }

        public Discount[] discounts { get; set; }
    }

    public class Discount
    {
        public string sku { get; set; }
        public int trigger { get; set; }
        public int bonus { get; set; }
    }
}
