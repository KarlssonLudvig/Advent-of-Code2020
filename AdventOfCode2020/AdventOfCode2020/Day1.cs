using System;
using System.Security.Cryptography;

namespace AdventOfCode2020
{
	public static class Day1
	{
		public static int GetPartOneAnswer()
		{
			var allLines = System.IO.File.ReadAllLines("C:\\Users\\Ludvig Karlsson\\source\\repos\\Advent-of-Code2020\\AdventOfCode2020\\AdventOfCode2020\\Data\\input.txt");
			var answer = GetExpenseReport(allLines);
			return answer.Value;
		}


		public static ExpenseReport GetExpenseReport(string[] allLines)
		{
			var expenseReport = new ExpenseReport();
			for (var i = 0; i < allLines.Length; i++)
			{
				expenseReport = SumTwoValues(allLines, i, expenseReport);
				if (expenseReport.Is2020)
					break;
			}
			return expenseReport;
		}

		public static ExpenseReport SumTwoValues(string[] allLines, int index, ExpenseReport expenseReport)
		{
			for (var j = index; j < allLines.Length; j++)
			{
				if (!SumLines(allLines[index], allLines[j]).Equals(2020)) continue;
				expenseReport.Is2020 = true;
				expenseReport.Value = int.Parse(allLines[index]) * int.Parse(allLines[j]);
				break;
			}
			return expenseReport;
		}
		private static int SumLines(string firstLine, string secondLine)
		{
			return int.Parse(firstLine) + int.Parse(secondLine);
		}

		private static int SumThreeLines(string firstLine, string secondLine, string thirdLine)
		{
			return int.Parse(firstLine) + int.Parse(secondLine) + int.Parse(thirdLine);
		}

		public static int GetPartTwoAnswer()
		{
			var allLines = System.IO.File.ReadAllLines("C:\\Users\\Ludvig Karlsson\\source\\repos\\Advent-of-Code2020\\AdventOfCode2020\\AdventOfCode2020\\Data\\DayOnePartTwoInput.txt");
			var expenseReport = GetThreeSumExpenseReport(allLines);
			return expenseReport.Value;
		}

		public static ExpenseReport GetThreeSumExpenseReport(string[] allLines)
		{
			var expenseReport = new ExpenseReport();
			for (var i = 0; i < allLines.Length; i++)
			{
				expenseReport = SumThreeValues(allLines, i, expenseReport);
			}
			return expenseReport;
		}

		private static ExpenseReport SumThreeValues(string[] allLines, int index, ExpenseReport expenseReport)
		{
			for (var i = index; i < allLines.Length; i++)
			{
				foreach (var line in allLines)
				{
					if (!SumThreeLines(allLines[index], allLines[i], line).Equals(2020)) continue;
					expenseReport.Is2020 = true;
					expenseReport.Value = int.Parse(allLines[index]) * int.Parse(allLines[i]) * int.Parse(line);
					break;
				}
			}
			return expenseReport;
		}
	}

	public class ExpenseReport
	{
		public bool Is2020 { get; set; }
		public int Value { get; set; }
	}
}
