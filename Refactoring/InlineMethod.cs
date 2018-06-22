namespace Refactoring
{
	public class InlineMethod
	{
		private int _numberOfLateDeliveries;

		private bool MoreThanFiveLateDeliveries() => _numberOfLateDeliveries > 5;

		private int GetRatingBefore() => MoreThanFiveLateDeliveries() ? 2 : 1;
		private int GetRatingAfter() => _numberOfLateDeliveries > 5 ? 2 : 1;
	}
}