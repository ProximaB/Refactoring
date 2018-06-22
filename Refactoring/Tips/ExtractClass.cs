namespace Refactoring.Tips
{
	public class ExtractClass
	{
		private class PersonBefore
		{
			private string _name;
			private string _officeAreaCode;
			private string _officeNumber;

			public string GetName() => _name;

			public string GetTelephoneNumber() => $"( {_officeAreaCode} ) {_officeNumber}";

			private string GetOfficeAreaCode() => _officeAreaCode;

			private void SetOfficeAreaCode(string arg)
			{
				_officeAreaCode = arg;
			}

			private string GetOfficeNumber() => _officeNumber;

			private void SetOfficeNumber(string arg)
			{
				_officeNumber = arg;
			}
		}

		public class PersonAfter
		{
			public string Name { get; private set; }
			public string OfficeNumber { get; private set; }
			
			private readonly TelephoneNumber _telephoneNumber;

			public PersonAfter(TelephoneNumber telephoneNumber)
			{
				_telephoneNumber = telephoneNumber;
			}

			public string GetTelephoneNumber() => _telephoneNumber.GetTelephoneNumber();

			public string GetOfficeAreaCode() => _telephoneNumber.AreaCode;

			private void SetOfficeNumber(string arg)
			{
				OfficeNumber = arg;
			}
		}

		public class TelephoneNumber
		{
			public string AreaCode { get; private set; }
			public string Number { get; private set; }

			public void SetAreaCode(string arg)
			{
				AreaCode = arg;
			}

			public void SetNumber(string number)
			{
				Number = number;
			}

			public string GetTelephoneNumber() => $"( {AreaCode} ) {Number}";
		}
	}
}