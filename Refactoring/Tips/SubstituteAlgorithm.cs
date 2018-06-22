using System.Linq;

namespace Refactoring.Tips
{
	public class SubstituteAlgorithm
	{
		private string FoundPersonBefore(string[] people)
		{
			for (var i = 0; i < people.Length; i++)
			{
				if (people[i].Equals("Don")) return "Don";
				if (people[i].Equals("John")) return "John";
				if (people[i].Equals("Kent")) return "Kent";
			}

			return "";
		}

		private string FoundPersonAfter(string[] people)
		{
			var candidates = new[] {"Don", "John", "Kent"};
			for (var i = 0; i < people.Length; i++)
				if (candidates.Contains(people[i]))
					return people[i];
			return "";
		}
	}
}