using System.Collections.Immutable;

namespace AdventOfCode2025.Lib;

public static class Day06 {
	private enum Operator {
		Plus,
		Multiply
	}

	private class Problem {
		public List<long> Numbers = [];
		public Operator Operator = Operator.Plus;

		public long Solve() => Operator switch {
			Operator.Plus => Numbers.Aggregate((long)0, (x, y) => x + y),
			Operator.Multiply => Numbers.Aggregate((long)1, (x, y) => x * y),
			_ => throw new NotImplementedException(),
		};
	}

	public static long Part1(IEnumerable<string> input) {
		List<Problem> problems = [];
		bool firstLine = true;
		foreach (string s in input) {
			if (firstLine) {
				problems = [.. s.Split(' ').Where(z => z != string.Empty).Select(z => new Problem {
					Numbers = [long.Parse(z)]
				})];
				firstLine = false;
			} else if (s[0] == '+' || s[0] == '*') {
				foreach (var (op, problem) in s.Split(' ').Where(z => z != string.Empty).Zip(problems)) {
					problem.Operator = op == "+" ? Operator.Plus : Operator.Multiply;
				}
			} else {
				foreach (var (number, problem) in s.Split(' ').Where(z => z != string.Empty).Zip(problems)) {
					problem.Numbers.Add(long.Parse(number));
				}
			}
		}
		return problems.Sum(p => p.Solve());
	}

	public static long Part2(IEnumerable<string> input) {
		List<Problem> problems = [];
		char[][] inputArray = [.. input.Select(s => s.PadRight(input.Max(z => z.Length)).ToArray())];
		Problem currentProblem = new();
		for (int x = 0; x < inputArray[0].Length; ++x) {
			if (Enumerable.Range(0, inputArray.Length).All(y => inputArray[y][x] == ' ')) {
				problems.Add(currentProblem);
				currentProblem = new();
			} else {
				if (inputArray[^1][x] != ' ') {
					currentProblem.Operator = inputArray[^1][x] == '+' ? Operator.Plus : Operator.Multiply;
				}
				currentProblem.Numbers.Add(
					long.Parse(
						new string(
							Enumerable.Range(0, inputArray.Length - 1).Select(y => inputArray[y][x]).ToArray()
						).Trim()
					)
				);
			}
		}
		problems.Add(currentProblem);
		return problems.Sum(p => p.Solve());
	}
}
