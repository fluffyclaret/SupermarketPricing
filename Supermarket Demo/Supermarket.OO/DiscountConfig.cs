using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.OO
{
    public class DiscountConfig : IDiscountConfig
    {
        public string Read()
        {
            return File.ReadAllText("BulkDiscount.config");
        }
    }
}
