using System;
using BenchmarkDotNet.Running;
using Refactoring.Tips;

namespace Refactoring
{
	public class Program
	{
		public static void Main()
		{
			var bench = BenchmarkRunner.Run<SplitTemporaryVariable>();
			Console.ReadKey();
		}
	}
}