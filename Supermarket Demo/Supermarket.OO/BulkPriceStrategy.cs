using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Supermarket.Core;

namespace Supermarket.OO
{
    public class BulkDiscountPriceStrategy : IPricingStrategy
    {
        private int _total;

        public BulkDiscountPriceStrategy(int trigger, int bonus)
        {
            this.Trigger = trigger;
            this.Bonus = bonus;
            _total = (trigger + bonus);
        }

        public int Trigger { get; private set; }

        public int Bonus { get; private set; }

        public decimal GetPrice(Product product, int number)
        {
            decimal price = 0;

            int place = number % (Trigger + Bonus);

            if (place >0 && place <= Trigger)
            {
                price = product.UnitPrice;
            }

            return price;
        }
    }
}
