﻿using System;

namespace Refactoring
{
	internal class Program
	{
		private double _capital;
		private double _duration;
		private double _income;
		private double _intRate;
		private double ADJ_FACTOR;

		private static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public double getAdjustedCapitalBefore()
		{
			var result = 0.0;
			if (_capital > 0.0)
				if (_intRate > 0.0 && _duration > 0.0)
					result = _income / _duration * ADJ_FACTOR;
			return result;
		}

		public double GetAdjustedCapitalAfter()
		{
			if (_capital <= 0.0) return 0.0;
			if (_intRate <= 0.0 || _duration <= 0.0) return 0.0;
			return _income / _duration * ADJ_FACTOR;
		}
	}
}