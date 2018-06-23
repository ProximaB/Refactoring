using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ChangeBidirectionalAssociationToUnidirectional
	{
		public class OrderBefore
		{
			public CustomerBefore Customer { get; set; }

			public void SetCustomer(CustomerBefore arg)
			{
				Customer?.FriendOrders().Remove(this);
				Customer = arg;
				Customer?.FriendOrders().Add(this);
			}

			public double GetDiscountedPrice() => GetGrossPrice() * (1 - Customer.GetDiscount());

			public double GetGrossPrice() => 0;
		}

		public class CustomerBefore
		{
			private readonly HashSet<OrderBefore> _orders = new HashSet<OrderBefore>();

			private void AddOrder(OrderBefore arg)
			{
				arg.SetCustomer(this);
			}

			public HashSet<OrderBefore> FriendOrders() => _orders;

			private double GetPriceFor(OrderBefore order) => order.GetDiscountedPrice();

			public int GetDiscount() => 0;
		}

		public class OrderAfter
		{
			public CustomerAfter Customer { get; set; }

			public void SetCustomer(CustomerAfter arg)
			{
				Customer?.FriendOrders().Remove(this);
				Customer = arg;
				Customer?.FriendOrders().Add(this);
			}

			private int GetGrossPrice() => 0;

			public double GetDiscountedPrice(CustomerAfter customerAfter) => 0.0;
		}

		public class CustomerAfter
		{
			private readonly HashSet<OrderAfter> _orders = new HashSet<OrderAfter>();

			private void AddOrder(OrderAfter arg)
			{
				arg.SetCustomer(this);
			}

			public HashSet<OrderAfter> FriendOrders() => _orders;

			public double GetPriceFor(OrderAfter order) =>
				_orders.Contains(order) ? order.GetDiscountedPrice(this) : double.NaN;

			public static int GetDiscount() => 0;
		}
	}
}