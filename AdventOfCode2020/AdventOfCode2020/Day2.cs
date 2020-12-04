using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	public static class Day2
	{
		public static int GetPartOneAnswer()
		{
			var allLines = System.IO.File.ReadAllLines("C:\\Users\\Ludvig Karlsson\\source\\repos\\Advent-of-Code2020\\AdventOfCode2020\\AdventOfCode2020\\Data\\DayTwoPartOneInput.txt");
			return allLines.Select(SplitLines).Count(IsValid);
		}

		private static bool IsValid(KeyValuePair<char, string[]> lines)
		{
			var occurrences = lines.Value.Last().Count(letter => letter.Equals(lines.Key));
			var span = Array.ConvertAll(lines.Value.First().Split('-'), int.Parse);
			return occurrences >= span.First() && occurrences <= span.Last();
		}

		private static KeyValuePair<char, string[]> SplitLines(string line)
		{
			var splitLines = line.Split(':');
			var letter = splitLines.First().ToCharArray().Last();
			var policy = splitLines.First().Split(splitLines.First().Substring(splitLines.First().Length - 1)).First();
			return new KeyValuePair<char, string[]>(letter, new []{policy, splitLines.Last()});
		}

		public static int GetPartTwoAnswer()
		{
			var allLines = System.IO.File.ReadAllLines("C:\\Users\\Ludvig Karlsson\\source\\repos\\Advent-of-Code2020\\AdventOfCode2020\\AdventOfCode2020\\Data\\DayTwoPartOneInput.txt");
			return allLines.Select(SplitLines).Count(IsValidPartTwo);
		}

		private static bool IsValidPartTwo(KeyValuePair<char, string[]> lines)
		{
			var span = Array.ConvertAll(lines.Value.First().Split('-'), int.Parse);
			var password = lines.Value.Last().Trim();
			return password[span.First()-1] == lines.Key && password[span.Last()-1] != lines.Key ||
			       password[span.Last()-1] == lines.Key && password[span.First()-1] != lines.Key;
		}
	}
}