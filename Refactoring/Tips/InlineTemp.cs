namespace Refactoring.Tips
{
	public class InlineTemp
	{
		public Order2 Order;

		public bool InlineTempBefore()
		{
			var basePrice = Order.BasePrice();
			return basePrice > 1000;
		}

		public bool InlineTempAfter() => Order.BasePrice() > 1000;
	}

	public class Order2
	{
		public int BasePrice() => 1000;
	}
}