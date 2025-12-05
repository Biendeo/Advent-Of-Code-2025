using AdventOfCode2025.Lib;

namespace AdventOfCode2025.Tests;

public class Day05Tests {
	private const string _input = """
		3-5
		10-14
		16-20
		12-18

		1
		5
		8
		11
		17
		32
		""";

	[Fact]
	public void Part1() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(3, Day05.Part1(splitInput));
	}

	[Fact]
	public void Part2() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(14, Day05.Part2(splitInput));
	}
}
