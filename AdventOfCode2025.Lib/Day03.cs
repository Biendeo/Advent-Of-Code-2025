namespace AdventOfCode2025.Lib;

public static class Day03 {
	public static long GetHighestSubstring(string s, int n) {
		string highestValue = string.Join("", Enumerable.Repeat('0', n));
		Stack<int> indicies = new(0);
		indicies.Push(0);
		while (indicies.Count != 1 || indicies.Peek() != s.Length) {
			string currentStack = string.Join("", indicies.Reverse().Select(i => s[i]));
			int comparison = currentStack.CompareTo(highestValue[..indicies.Count]);
			if (indicies.Count == n && comparison > 0) {
				highestValue = currentStack;
			}
			if (indicies.Peek() == s.Length - 1) {
				if (indicies.Count == 1) {
					indicies.Push(indicies.Pop() + 1);
				} else {
					indicies.Pop();
					indicies.Push(indicies.Pop() + 1);
				}
			} else if (indicies.Count == n) {
				indicies.Push(indicies.Pop() + 1);
			} else if (comparison < 0) {
				if (indicies.Count == 1) {
					indicies.Push(indicies.Pop() + 1);
				} else if (indicies.Peek() == s.Length - 1) {
					indicies.Pop();
					indicies.Push(indicies.Pop() + 1);
				} else {
					indicies.Push(indicies.Pop() + 1);
				}
			} else {
				indicies.Push(indicies.Peek() + 1);
			}
		}
		Console.WriteLine(highestValue);
		return long.Parse(highestValue);
	}

	public static long Part1(IEnumerable<string> input) {
		return input.Sum(s => GetHighestSubstring(s, 2));
	}

	public static long Part2(IEnumerable<string> input) {
		return input.Sum(s => GetHighestSubstring(s, 12));
	}
}
