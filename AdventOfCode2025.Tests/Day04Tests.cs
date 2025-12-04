using AdventOfCode2025.Lib;

namespace AdventOfCode2025.Tests;

public class Day04Tests {
	private const string _input = """
		..@@.@@@@.
		@@@.@.@.@@
		@@@@@.@.@@
		@.@@@@..@.
		@@.@@@@.@@
		.@@@@@@@.@
		.@.@.@.@@@
		@.@@@.@@@@
		.@@@@@@@@.
		@.@.@@@.@.
		""";

	[Fact]
	public void Part1() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(13, Day04.Part1(splitInput));
	}

	[Fact]
	public void Part2() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(43, Day04.Part2(splitInput));
	}
}
