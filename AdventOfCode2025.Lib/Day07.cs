namespace AdventOfCode2025.Lib;

public static class Day07 {
	public static int Part1(IEnumerable<string> input) {
		int splits = 0;
		char[][] inputGrid = [.. input.Select(c => c.ToArray())];
		for (int y = 1; y < inputGrid.Length; ++y) {
			for (int x = 0; x < inputGrid[y].Length; ++x) {
				char above = inputGrid[y - 1][x];
				if (above == 'S' || above == '|') {
					if (inputGrid[y][x] == '.') {
						inputGrid[y][x] = '|';
					} else if (inputGrid[y][x] == '^') {
						inputGrid[y][x - 1] = '|';
						inputGrid[y][x + 1] = '|';
						++splits;
					}
				}
			}
		}
		return splits;
	}
	
	public static long Part2(IEnumerable<string> input) {
		char[][] inputGrid = [.. input.Select(c => c.ToArray())];
		long[,] inputTimelines = new long[inputGrid[0].Length, inputGrid.Length];
		inputTimelines[inputGrid[0].IndexOf('S'), 0] = 1;
		long timelines = 0;
		for (int y = 1; y < inputGrid.Length; ++y) {
			for (int x = 0; x < inputGrid[y].Length; ++x) {
				char above = inputGrid[y - 1][x];
				if (above == 'S' || above == '|') {
					inputTimelines[x, y] += inputTimelines[x, y - 1];
					if (inputGrid[y][x] == '.') {
						inputGrid[y][x] = '|';
					} else if (inputGrid[y][x] == '^') {
						inputGrid[y][x - 1] = '|';
						inputTimelines[x - 1, y] += inputTimelines[x, y];
						inputGrid[y][x + 1] = '|';
						inputTimelines[x + 1, y] += inputTimelines[x, y];
					}
				}
				if (y == inputGrid.Length - 1) {
					timelines += inputTimelines[x, y];
				}
			}
		}
		return timelines;
	}
}
