namespace AdventOfCode2025.Lib;

public static class Day02 {
	public static IEnumerable<long> LongRange(long start, long count) {
		for (long i = start; i < start + count; ++i) {
			yield return i;
		}
	}

	public static IEnumerable<IEnumerable<T>> Chunk<T>(IEnumerable<T> e, int chunkSize) {
		while (e.Count() >= chunkSize) {
			yield return e.Take(chunkSize);
			e = e.Skip(chunkSize);
		}
	}

	public static long Part1(string input) {
		long invalidIdSum = 0;
		foreach (string s in input.Split(',')) {
			long start = long.Parse(s.Split('-')[0]);
			long end = long.Parse(s.Split('-')[1]);
			foreach (long x in LongRange(start, end - start + 1)) {
				string xs = x.ToString();
				if (xs.Length % 2 == 0 && xs[..(xs.Length / 2)].SequenceEqual(xs[(xs.Length / 2)..])) {
					invalidIdSum += x;
				}
			}
		}
		return invalidIdSum;
	}

	public static long Part2(string input) {
		long invalidIdSum = 0;
		foreach (string s in input.Split(',')) {
			long start = long.Parse(s.Split('-')[0]);
			long end = long.Parse(s.Split('-')[1]);
			foreach (long x in LongRange(start, end - start + 1)) {
				string xs = x.ToString();
				if (Enumerable.Range(1, xs.Length / 2).Any(l => xs.Length % l == 0 && !Chunk(xs, l).Select(q => string.Join("", q)).Distinct().Skip(1).Any())) {
					invalidIdSum += x;
				}
			}
		}
		return invalidIdSum;
	}
}
