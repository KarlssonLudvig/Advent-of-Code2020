using System;
using System.Data;
using System.Xml.Schema;


namespace AdventOfCode2020
{
	public static class Day3
	{
		public static int GetPartOneAnswer()
		{
			var allLines = System.IO.File.ReadAllLines("C:\\Users\\Ludvig Karlsson\\source\\repos\\Advent-of-Code2020\\AdventOfCode2020\\AdventOfCode2020\\Data\\DayThreePartOneInput.txt");
			return GetNumberOfTrees(allLines, 3,0);
		}

		private static int GetNumberOfTrees(string[] allLines, int stepsRight, int numberOfRows)
		{
			var numberOfTrees = 0;
			var numberOfSkips = numberOfRows;
			foreach (var line in allLines)
			{
				if (line == allLines[0])
					continue;

				if (numberOfSkips > 0)
				{
					numberOfSkips--;
					continue;
				}

				if (stepsRight >= line.Length)
				{
					var over = stepsRight - line.Length;
					stepsRight = 0;
					for (var j = 0; j < over; j++)
					{
						stepsRight++;
					}
				}
				var y = line.Length;
				var x = line[stepsRight];
				if (line[stepsRight].Equals('#'))
					numberOfTrees++;
				stepsRight += 3;
				numberOfSkips = numberOfRows;
			}
			return numberOfTrees;
		}

		public static int GetPartTwoAnswer()
		{
			var allLines = System.IO.File.ReadAllLines("C:\\Users\\Ludvig Karlsson\\source\\repos\\Advent-of-Code2020\\AdventOfCode2020\\AdventOfCode2020\\Data\\DayThreePartOneInput.txt");
			var x = GetNumberOfTrees(allLines, 1, 0);
			var y = GetNumberOfTrees(allLines, 3, 0);
			var z = GetNumberOfTrees(allLines, 5, 0);
			var k = GetNumberOfTrees(allLines, 7, 0);
			var t = GetNumberOfTrees(allLines, 1, 1);
			var result = x * y * z * k * t;
			return result;
		}
	}
}
