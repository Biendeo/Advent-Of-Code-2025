using AdventOfCode2025.Lib;

namespace AdventOfCode2025.Tests;

public class Day03Tests {
	private const string _input = """
		987654321111111
		811111111111119
		234234234234278
		818181911112111
		""";

	[Fact]
	public void Part1() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(357, Day03.Part1(splitInput));
	}

	[Fact]
	public void Part2() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(3121910778619, Day03.Part2(splitInput));
	}
}
