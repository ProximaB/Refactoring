namespace Refactoring.Tips
{
	public class HideDelegateBefore
	{
		private class Person
		{
			private Department _department;

			public Department GetDepartment() => _department;

			public void SetDepartment(Department arg)
			{
				_department = arg;
			}
		}

		private class Department
		{
			private readonly Person _manager;
			private string _chargeCode;

			public Department(Person manager) => _manager = manager;

			public Person GetManager() => _manager;
		}
	}

	public class HideDelegateAfter
	{
		private class Person
		{
			private Department _department;

			public Department GetDepartment() => _department;

			public void SetDepartment(Department arg)
			{
				_department = arg;
			}

			public Person GetManager() => _department.GetManager();
		}

		private class Department
		{
			private readonly Person _manager;
			private string _chargeCode;

			public Department(Person manager) => _manager = manager;

			public Person GetManager() => _manager;
		}
	}
}