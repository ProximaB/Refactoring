namespace Refactoring.Tips
{
	public class InlineClassBefore
	{
		private class Person
		{
			private readonly TelephoneNumber _officeTelephone = new TelephoneNumber();
			private string _name;

			public string GetName() => _name;

			public string GetTelephoneNumber() => _officeTelephone.GetTelephoneNumber();

			private TelephoneNumber GetOfficeTelephone() => _officeTelephone;
		}

		private class TelephoneNumber
		{
			private string _areaCode;

			private string _number;

			public string GetTelephoneNumber() => $"( {_areaCode} ) {_number}";

			private string GetAreaCode() => _areaCode;

			private void SetAreaCode(string arg)
			{
				_areaCode = arg;
			}

			private string GetNumber() => _number;

			private void SetNumber(string arg)
			{
				_number = arg;
			}
		}
	}

	public class InlineClassAfter
	{
		private class Person
		{
			private string _areaCode;
			private string _name;
			private string _number;

			public string GetName() => _name;

			public string GetTelephoneNumber() => $"( {_areaCode} ) {_number}";

			private string GetAreaCode() => _areaCode;

			private void SetAreaCode(string arg)
			{
				_areaCode = arg;
			}

			private string GetNumber() => _number;

			private void SetNumber(string arg)
			{
				_number = arg;
			}
		}
	}
}