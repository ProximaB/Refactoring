using System;
using BenchmarkDotNet.Running;
using Refactoring.Tips;

namespace Refactoring
{
	public class Program
	{
		public static void Main()
		{
			//var bench = BenchmarkRunner.Run<SplitTemporaryVariable>();
			var bench = BenchmarkRunner.Run<IntroduceExplainingVariable>();
			Console.ReadKey();
		}
	}
}