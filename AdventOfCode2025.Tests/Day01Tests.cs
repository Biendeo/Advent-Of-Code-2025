using AdventOfCode2025.Lib;

namespace AdventOfCode2025.Tests;

public class Day01Tests {
	private const string _input = """
		L68
		L30
		R48
		L5
		R60
		L55
		L1
		L99
		R14
		L82
		""";

	[Theory]
	[InlineData([0, 100, 0])]
	[InlineData([40, 100, 40])]
	[InlineData([1550, 100, 50])]
	[InlineData([-39, 100, 61])]
	[InlineData([-3901, 100, 99])]
	public void PositiveMod(int x, int m, int r) {
		Assert.Equal(r, Day01.PositiveMod(x, m));
	}

	[Fact]
	public void Part1() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(3, Day01.Part1(splitInput));
	}

	[Fact]
	public void Part2() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(6, Day01.Part2(splitInput));
	}
}
