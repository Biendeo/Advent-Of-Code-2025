using AdventOfCode2025.Lib;
using AdventOfCode2025.Properties;
using System.Diagnostics;

static void TimeAndReportResult<T>(Func<T> action, int day, int part) {
	Console.WriteLine($"Day {day:D2} - Part {part}");
	Stopwatch stopwatch = new();
	stopwatch.Start();
	T result = action();
	stopwatch.Stop();
	Console.WriteLine(result);
	Console.WriteLine($"Solved in {stopwatch.ElapsedMilliseconds:n0}ms");
	Console.WriteLine();
}

List<(Func<object> action, int day, int part)> steps = [
	(() => Day01.Part1(Resources.Day01.Trim().Split(Environment.NewLine)), 1, 1),
	(() => Day01.Part2(Resources.Day01.Trim().Split(Environment.NewLine)), 1, 2),
	(() => Day02.Part1(Resources.Day02.Trim()), 2, 1),
	(() => Day02.Part2(Resources.Day02.Trim()), 2, 2),
	(() => Day03.Part1(Resources.Day03.Trim().Split(Environment.NewLine)), 3, 1),
	(() => Day03.Part2(Resources.Day03.Trim().Split(Environment.NewLine)), 3, 2),
];

steps.ForEach(z => TimeAndReportResult(z.action, z.day, z.part));
