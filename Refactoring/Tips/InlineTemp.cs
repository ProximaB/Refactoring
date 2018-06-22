namespace Refactoring.Tips
{
	public class InlineTemp
	{
		public Order2 _order;

		public bool InlineTempBefore()
		{
			var basePrice = _order.BasePrice();
			return basePrice > 1000;
		}

		public bool InlineTempAfter() => _order.BasePrice() > 1000;
	}

	public class Order2
	{
		public int BasePrice() => 1000;
	}
}