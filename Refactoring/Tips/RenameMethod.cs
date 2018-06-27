namespace Refactoring.Tips
{
	public class RenameMethod
	{
		private int _officeAreaCode;
		private int _officeNumber;

		public string GetTelephoneNumberBefore() => $"( {_officeAreaCode.ToString()} ) {_officeNumber.ToString()}";

		public string GetTelephoneNumberAfter() => GetOfficeTelephoneNumber();

		private string GetOfficeTelephoneNumber() => $"( {_officeAreaCode.ToString()} ) {_officeNumber.ToString()}";
	}
}