using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Core;

namespace Supermarket.OO
{
    public interface IProductRepository
    {
        Product Fetch(string sku);
    }
}
