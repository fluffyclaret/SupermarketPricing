namespace Supermarket.Core
{
    public class DiscountDeserialiser : IDiscountDeserialiser
    {
        public Discounts Deserialise(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Discounts>(value);
        }
    }
}
