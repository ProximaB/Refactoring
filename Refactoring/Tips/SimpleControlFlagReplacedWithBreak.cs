using System;

namespace Refactoring.Tips
{
	public class SimpleControlFlagReplacedWithBreak
	{
		private void Before(string[] people)
		{
			var found = false;
			for (var i = 0; i < people.Length; i++)
				if (!found)
				{
					if (people[i].Equals("Don"))
					{
						SendAlert();
						found = true;
					}

					if (people[i].Equals("John"))
					{
						SendAlert();
						found = true;
					}
				}
		}

		private static void SendAlert()
		{
			Console.WriteLine("Hello!");
		}

		private void After(string[] people)
		{
			for (var i = 0; i < people.Length; i++)
			{
				if (people[i].Equals("Don"))
				{
					SendAlert();
					break;
				}

				if (people[i].Equals("John"))
				{
					SendAlert();
					break;
				}
			}
		}
	}
}