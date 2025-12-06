using AdventOfCode2025.Lib;

namespace AdventOfCode2025.Tests;

public class Day06Tests {
	private const string _input = """
		123 328  51 64 
		 45 64  387 23 
		  6 98  215 314
		*   +   *   +  
		""";

	[Fact]
	public void Part1() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(4277556, Day06.Part1(splitInput));
	}

	[Fact]
	public void Part2() {
		IEnumerable<string> splitInput = _input.Trim().Split(Environment.NewLine);
		Assert.Equal(3263827, Day06.Part2(splitInput));
	}
}
