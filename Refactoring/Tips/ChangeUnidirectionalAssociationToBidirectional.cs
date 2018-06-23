using System.Collections.Generic;

namespace Refactoring.Tips
{
	public class ChangeUnidirectionalAssociationToBidirectional
	{
		public class Order
		{
			private readonly List<Customer> _customers = new List<Customer>();
			public Customer Customer { get; private set; }

			public void SetCustomer(Customer arg)
			{
				Customer?.FriendOrders().Remove(this);
				Customer = arg;
				Customer?.FriendOrders().Add(this);
			}

			public void AddCustomer(Customer arg)
			{
				arg.FriendOrders().Add(this);
				_customers.Add(arg);
			}

			public void RemoveCustomer(Customer arg)
			{
				arg.FriendOrders().Remove(this);
				_customers.Remove(arg);
			}
		}

		public class Customer
		{
			private readonly HashSet<Order> _orders = new HashSet<Order>();

			public HashSet<Order> FriendOrders() => _orders;

			private void AddOrder(Order arg)
			{
				arg.SetCustomer(this);
			}

			private void RemoveOrder(Order arg)
			{
				arg.RemoveCustomer(this);
			}
		}
	}
}