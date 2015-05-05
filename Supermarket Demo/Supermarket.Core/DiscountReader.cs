namespace Supermarket.Core
{
    public class DiscountReader : IDiscountReader
    {
        private IDiscountDeserialiser _deserialiser;
        private IDiscountConfig _config;

        public DiscountReader(IDiscountDeserialiser deserialiser, IDiscountConfig config)
        {
            _deserialiser = deserialiser;
            _config = config;
        }

        public Discounts Read()
        {
            var content = _config.Read();

            return _deserialiser.Deserialise(content);
        }
    }
}
