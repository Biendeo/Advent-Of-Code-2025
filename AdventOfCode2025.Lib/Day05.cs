namespace AdventOfCode2025.Lib;

using Range = (long Start, long End);

public static class Day05 {
	public static (List<Range> ranges, List<long> available) ParseInput(IEnumerable<string> input) {
		List<Range> ranges = [];
		List<long> available = [];
		bool readingRanges = true;
		foreach (string s in input) {
			if (s == "") {
				readingRanges = false;
				continue;
			}
			if (readingRanges) {
				ranges.Add((long.Parse(s.Split('-')[0]), long.Parse(s.Split('-')[1])));
			} else {
				available.Add(long.Parse(s));
			}
		}
		return (ranges, available);
	}

	public static int Part1(IEnumerable<string> input) {
		(List<Range> ranges, List<long> available) = ParseInput(input);
		return available.Count(a => ranges.Any(r => r.Start <= a && r.End >= a));
	}

	public static long Part2(IEnumerable<string> input) {
		(List<Range> ranges, _) = ParseInput(input);
		List<Range> outputRanges = [];
		foreach (Range r in ranges) {
			Range finalisedRange = r;
			List<Range> overlappingRanges = outputRanges.Where(r2 => !(r.End < r2.Start || r.Start > r2.End)).ToList();
			foreach (Range r2 in overlappingRanges) {
				outputRanges.Remove(r2);
				finalisedRange = (Math.Min(finalisedRange.Start, r2.Start), Math.Max(finalisedRange.End, r2.End));
			}
			outputRanges.Add(finalisedRange);
		}
		return outputRanges.Sum(r => r.End - r.Start + 1);
	}
}
