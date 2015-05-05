using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.OO
{
    public class Discounts
    {
        public Discount[] discounts { get; set; }
    }

    public class Discount
    {
        public string sku { get; set; }
        public int trigger { get; set; }
        public int bonus { get; set; }
    }
}
