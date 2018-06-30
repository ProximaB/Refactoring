namespace Refactoring.Tips
{
	public class PreserveWholeObjectBefore
	{
		public class Room
		{
			private bool WithinPlan(HeatingPlan plan)
			{
				var low = DaysTempRange().GetLow();
				var high = DaysTempRange().GetHigh();
				return plan.WithinRange(low, high);
			}

			private static TempRange DaysTempRange() => new TempRange();
		}

		public class HeatingPlan
		{
			private TempRange _range;
			public bool WithinRange(int low, int high) => low >= _range.GetLow() && high <= _range.GetHigh();
		}

		public class TempRange
		{
			public int GetHigh() => 0;

			public int GetLow() => 0;
		}
	}

	public class PreserveWholeObjectAfter
	{
		public class Room
		{
			private bool WithinPlan(HeatingPlan plan) => plan.WithinRange(DaysTempRange());

			public static TempRange DaysTempRange() => new TempRange();
		}

		public class HeatingPlan
		{
			private TempRange _range;

			public bool WithinRange(TempRange roomRange) => _range.Includes(roomRange);
		}

		public class TempRange
		{
			public int GetHigh() => 0;

			public int GetLow() => 0;

			public bool Includes(TempRange arg) => arg.GetLow() >= GetLow() && arg.GetHigh() <= GetHigh();
		}
	}
}