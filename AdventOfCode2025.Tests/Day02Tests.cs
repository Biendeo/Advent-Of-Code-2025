using AdventOfCode2025.Lib;

namespace AdventOfCode2025.Tests;

public class Day02Tests {
	private const string _input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\r\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\r\n824824821-824824827,2121212118-2121212124";

	[Fact]
	public void LongRange() {
		Assert.Equal([123, 124, 125, 126], Day02.LongRange(123, 4));
	}

	[Fact]
	public void Chunk() {
		Assert.Equal(["123".ToCharArray(), "456".ToCharArray(), "789".ToCharArray()], Day02.Chunk("123456789", 3));
	}

	[Fact]
	public void Part1() {
		Assert.Equal(1227775554, Day02.Part1(_input.Trim()));
	}

	[Fact]
	public void Part2() {
		Assert.Equal(4174379265, Day02.Part2(_input.Trim()));
	}
}
