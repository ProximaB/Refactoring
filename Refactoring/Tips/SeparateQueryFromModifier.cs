using System;

namespace Refactoring.Tips
{
	public class SeparateQueryFromModifier
	{
		private string FoundMiscreantBefore(string[] people)
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

		private void CheckSecurityBefore(string[] people)
		{
			SomeLaterCode(FoundMiscreantBefore(people));
		}

		private static void SendAlert()
		{
			Console.WriteLine("Hello!");
		}

		private static void SomeLaterCode(string found)
		{
			Console.WriteLine(found);
		}


		private static void SendAlert(string[] people)
		{
			if (!FoundPerson(people).Equals("")) SendAlert();
		}

		private static string FoundPerson(string[] people)
		{
			for (var i = 0; i < people.Length; i++)
			{
				if (people[i].Equals("Don")) return "Don";
				if (people[i].Equals("John")) return "John";
			}

			return string.Empty;
		}

		private void CheckSecurity(string[] people)
		{
			SendAlert(people);
			SomeLaterCode(FoundPerson(people));
		}
	}
}