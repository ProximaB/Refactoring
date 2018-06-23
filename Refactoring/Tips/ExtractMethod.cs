using System;
using System.Collections.Generic;
using System.Globalization;

namespace Refactoring.Tips
{
	public class ExtractMethodBefore
	{
		private string _name;
		private Order _orders;

		private void PrintOwing()
		{
			var e = _orders.Elements();
			var outstanding = 0.0;

			// print banner
			Console.WriteLine("**************************");
			Console.WriteLine("***** Customer Owes ******");
			Console.WriteLine("**************************");

			// calculate outstanding
			var enumerator = e.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var each = enumerator.Current;
				outstanding += each.GetAmount();
			}

			//print details
			Console.WriteLine("name:" + _name);
			Console.WriteLine("amount" + outstanding);
		}
	}

	public class ExtractMethodAfter
	{
		private string _name;
		private Order _orders;

		private void PrintOwing()
		{
			PrintBanner();
			PrintDetails();
		}

		private void PrintDetails()
		{
			Console.WriteLine($"name: {_name}");
			Console.WriteLine($"amount: {GetOutstanding().ToString(CultureInfo.CurrentCulture)}");
		}

		private static void PrintBanner()
		{
			Console.WriteLine("**************************");
			Console.WriteLine("***** Customer Owes ******");
			Console.WriteLine("**************************");
		}

		private double GetOutstanding()
		{
			var result = 0.0;
			var enumerator = _orders.Elements().GetEnumerator();
			while (enumerator.MoveNext())
			{
				var each = enumerator.Current;
				result += each.GetAmount();
			}

			return result;
		}
	}

	public class Order
	{
		public double GetAmount() => 0.1;

		public IEnumerable<Order> Elements()
		{
			yield return new Order();
			yield return new Order();
			yield return new Order();
			yield return new Order();
		}
	}
}