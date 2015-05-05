namespace Supermarket.Core
{
    public interface IDiscountDeserialiser
    {
        Discounts Deserialise(string value);
    }
}
