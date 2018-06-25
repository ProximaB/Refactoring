using System;

namespace Refactoring.Tips
{
	public class UsingReturnWithControlFlagResult
	{
		private void Before(string[] people)
		{
			var found = "";
			for (var i = 0; i < people.Length; i++)
				if (found.Equals(""))
				{
					if (people[i].Equals("Don"))
					{
						SendAlert();
						found = "Don";
					}

					if (people[i].Equals("John"))
					{
						SendAlert();
						found = "John";
					}
				}

			SomeLaterCode(found);
		}

		private void SomeLaterCode(string found)
		{
			Console.WriteLine(found);
		}

		private static void SendAlert()
		{
			Console.WriteLine("Hello!");
		}

		private void After(string[] people)
		{
			SomeLaterCode(FoundMiscreant(people));
		}

		private static string FoundMiscreant(string[] people)
		{
			for (var i = 0; i < people.Length; i++)
			{
				if (people[i].Equals("Don"))
				{
					SendAlert();
					return "Don";
				}

				if (people[i].Equals("John"))
				{
					SendAlert();
					return "John";
				}
			}

			return string.Empty;
		}
	}
}