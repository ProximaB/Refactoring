namespace Refactoring.Tips
{
	public class ReplaceTempWithQuery
	{
		private int _itemPrice;
		private int _quantity;

		private double GetPriceBefore()
		{
			var basePrice = _quantity * _itemPrice;
			double discountFactor;
			if (basePrice > 1000) discountFactor = 0.95;
			else discountFactor = 0.98;
			return basePrice * discountFactor;
		}

		private double GetPriceAfter() => GetBasePrice() * DiscountFactor();

		private double DiscountFactor() => GetBasePrice() > 1000 ? 0.95 : 0.98;

		private int GetBasePrice() => _quantity * _itemPrice;
	}
}