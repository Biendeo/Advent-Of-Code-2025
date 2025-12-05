namespace AdventOfCode2025.Lib;

public static class Day03 {
	public static long GetHighestSubstring(string s, int n) {
		Stack<char> digits = new(n);
		for (int i = 0; i < s.Length; ++i) {
			char c = s[i];
			while (digits.Count > 0 && n - digits.Count < s.Length - i && digits.Peek() < c) {
				digits.Pop();
			}
			if (digits.Count < n) {
				digits.Push(c);
			}
		}
		return long.Parse(new([.. digits.Reverse()]));
	}

	public static long Part1(IEnumerable<string> input) {
		return input.Sum(s => GetHighestSubstring(s, 2));
	}

	public static long Part2(IEnumerable<string> input) {
		return input.Sum(s => GetHighestSubstring(s, 12));
	}
}
