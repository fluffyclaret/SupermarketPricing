using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Functional
{
    public class Basket
    {
        public void Start()
        {
            var products = new List<Product>();

            this.Add = product => products.Add(product);

            this.Count = () => products.Count;

            this.Price = () => products.Price();
        }

        public Action<Product> Add { get; private set; }

        public Func<int> Count { get; private set; }

        public Func<decimal> Price { get; private set; } 

    }
}
