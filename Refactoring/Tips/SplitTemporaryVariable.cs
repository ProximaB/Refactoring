using System;
using BenchmarkDotNet.Attributes;

namespace Refactoring.Tips
{
	public class SplitTemporaryVariable
	{
		private int _delay;
		private double _mass;
		private double _primaryForce;
		private double _secondaryForce;

		[Benchmark]
		[Arguments(1)]
		[Arguments(10000000)]
		public double GetDistanceTravelledBefore(int time)
		{
			double result;
			var acc = _primaryForce / _mass;
			var primaryTime = Math.Min(time, _delay);
			result = 0.5 * acc * primaryTime * primaryTime;
			var secondaryTime = time - _delay;

			if (secondaryTime > 0)
			{
				var primaryVel = acc * _delay;
				acc = (_primaryForce + _secondaryForce) / _mass;
				result += primaryVel * secondaryTime + 0.5 * acc * secondaryTime * secondaryTime;
			}

			return result;
		}

		[Benchmark]
		[Arguments(1)]
		[Arguments(10000000)]
		public double GetDistanceTravelledAfter(int time)
		{
			if (GetSecondaryTime(time) <= 0) return 0.5 * GetPrimaryAcc() * GetPowerOfPrimaryTime(time);

			return 0.5 * GetSecondaryTime(time) * (GetPrimaryAcc() * GetPowerOfPrimaryTime(time) + GetPrimaryVel() +
			              GetSecondaryAcc() * GetSecondaryTime(time));
		}

		private double GetPowerOfPrimaryTime(int time) => GetPrimaryTime(time) * GetPrimaryTime(time);

		private double GetSecondaryAcc() => (_primaryForce + _secondaryForce) / _mass;

		private double GetPrimaryVel() => GetPrimaryAcc() * _delay;

		private int GetSecondaryTime(int time) => time - _delay;

		private int GetPrimaryTime(int time) => Math.Min(time, _delay);

		private double GetPrimaryAcc() => _primaryForce / _mass;
	}
}