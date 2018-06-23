namespace Refactoring.Tips
{
	public class InlineTemp
	{
		public class Inline
		{
			public Order Order;

			public bool InlineTempBefore()
			{
				var basePrice = Order.BasePrice();
				return basePrice > 1000;
			}

			public bool InlineTempAfter() => Order.BasePrice() > 1000;
		}

		public class Order
		{
			public int BasePrice() => 1000;
		}
	}
}