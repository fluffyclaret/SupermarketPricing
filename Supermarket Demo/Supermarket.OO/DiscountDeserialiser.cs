using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.OO
{
    public class DiscountDeserialiser : IDiscountDeserialiser
    {
        public Discounts Deserialise(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Discounts>(value);
        }
    }
}
