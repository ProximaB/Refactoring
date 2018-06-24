namespace Refactoring.Tips
{
	public class ReplaceTypeCodeWithClass
	{
		private class PersonBefore
		{
			public static int O = 0;
			public static int A = 1;
			public static int B = 2;
			public static int AB = 3;

			private int _bloodGroup;

			public PersonBefore(int bloodGroup) => _bloodGroup = bloodGroup;

			public void SetBloodGroup(int arg)
			{
				_bloodGroup = arg;
			}

			public int GetBloodGroup() => _bloodGroup;
		}

		public class BloodGroup
		{
			public static readonly BloodGroup O = new BloodGroup(0);
			public static readonly BloodGroup A = new BloodGroup(1);
			public static readonly BloodGroup B = new BloodGroup(2);
			public static readonly BloodGroup AB = new BloodGroup(3);
			private static readonly BloodGroup[] Values = {O, A, B, AB};

			private readonly int _code;

			private BloodGroup(int code) => _code = code;

			private int GetCode() => _code;

			private static BloodGroup Code(int arg) => Values[arg];
		}

		public class PersonAfter
		{
			private BloodGroup _bloodGroup;

			public PersonAfter(BloodGroup bloodGroup) => _bloodGroup = bloodGroup;

			public BloodGroup GetBloodGroup() => _bloodGroup;

			public void SetBloodGroup(BloodGroup arg) { _bloodGroup = arg; }
		}
	}
}