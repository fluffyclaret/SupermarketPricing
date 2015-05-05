using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Core;

namespace Supermarket.OO
{
    public interface IStrategySelector
    {
        IPricingStrategy Create(string sku);
    }
}
