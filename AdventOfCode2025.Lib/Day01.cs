namespace AdventOfCode2025.Lib;

public static class Day01 {
	public static int PositiveMod(int x, int m) {
		return ((x % m) + m) % m;
	}

	public static int Part1(IEnumerable<string> input) {
		int dial = 50;
		int zeroes = 0;
		foreach (string s in input) {
			int magnitude = int.Parse(s[1..]);
			if (s[0] == 'L') {
				dial = PositiveMod(dial - magnitude, 100);
			} else {
				dial = PositiveMod(dial + magnitude, 100);
			}
			if (dial == 0)
				++zeroes;
		}
		return zeroes;
	}

	public static int Part2(IEnumerable<string> input) {
		int dial = 50;
		int zeroes = 0;
		foreach (string s in input) {
			int magnitude = int.Parse(s[1..]);
			zeroes += Math.Abs(magnitude / 100);
			magnitude %= 100;
			int newDial;
			if (s[0] == 'L') {
				newDial = dial - magnitude;
				if (dial != 0 && newDial <= 0) {
					++zeroes;
				}
			} else {
				newDial = dial + magnitude;
				if (newDial >= 100) {
					++zeroes;
				}
			}
			newDial = PositiveMod(newDial, 100);
			dial = newDial;
		}
		return zeroes;
	}
}
