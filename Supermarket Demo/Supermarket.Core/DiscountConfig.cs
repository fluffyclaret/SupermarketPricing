using System.IO;

namespace Supermarket.Core
{
    public class DiscountConfig : IDiscountConfig
    {
        public string Read()
        {
            return File.ReadAllText("BulkDiscount.config");
        }
    }
}
