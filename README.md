# SupermarketPricing
Supermarket pricing examples via TDD

Ensure you have installed the NUnit test runner Visual Studio plugin. 

Run the unit tests within Supermarket.Test for a demonstration of functionality.

Discounts are defined in the BulkDiscount.config file, as raw JSON. Only BulkDiscounts are supported for now.

For example, to create a discount 3 for the price of 2 offer on a product with SKU "001":

{
  "discounts":[
    { "sku":"001", "trigger":2, "bonus":1 }
  ]
}
