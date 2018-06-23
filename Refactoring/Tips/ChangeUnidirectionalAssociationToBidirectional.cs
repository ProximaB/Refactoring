using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ChangeUnidirectionalAssociationToBidirectional
	{
		public class OrderBefore
		{
			public CustomerBefore Customer { get; set; }
		}

		public class CustomerBefore
		{
			private readonly HashSet<OrderBefore> _orders = new HashSet<OrderBefore>();
			private HashSet<OrderBefore> FriendOrders() => _orders;
		}

		public class OrderAfter
		{
			private readonly List<CustomerAfter> _customers = new List<CustomerAfter>();
			public CustomerAfter CustomerAfter { get; private set; }

			public void SetCustomer(CustomerAfter arg)
			{
				CustomerAfter?.FriendOrders().Remove(this);
				CustomerAfter = arg;
				CustomerAfter?.FriendOrders().Add(this);
			}

			public void AddCustomer(CustomerAfter arg)
			{
				arg.FriendOrders().Add(this);
				_customers.Add(arg);
			}

			public void RemoveCustomer(CustomerAfter arg)
			{
				arg.FriendOrders().Remove(this);
				_customers.Remove(arg);
			}
		}

		public class CustomerAfter
		{
			private readonly HashSet<OrderAfter> _orders = new HashSet<OrderAfter>();

			public HashSet<OrderAfter> FriendOrders() => _orders;

			private void AddOrder(OrderAfter arg)
			{
				arg.SetCustomer(this);
			}

			private void RemoveOrder(OrderAfter arg)
			{
				arg.RemoveCustomer(this);
			}
		}
	}
}