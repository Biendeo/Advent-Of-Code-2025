namespace AdventOfCode2025.Lib;

using Point = (int X, int Y);

public static class Day04 {
	public static IEnumerable<Point> GetGridRange(int minX, int minY, int maxX, int maxY) {
		for (int y = minY; y < maxY; ++y) {
			for (int x = minX; x < maxX; ++x) {
				yield return (x, y);
			}
		}
	}

	public static IEnumerable<Point> GetNeighbors(Point p, int minX, int minY, int maxX, int maxY) {
		if (p.X > minX && p.Y > minY)
			yield return (p.X - 1, p.Y - 1);
		if (p.Y > minY)
			yield return (p.X, p.Y - 1);
		if (p.X < maxX - 1 && p.Y > minY)
			yield return (p.X + 1, p.Y - 1);
		if (p.X > minX)
			yield return (p.X - 1, p.Y);
		if (p.X < maxX - 1)
			yield return (p.X + 1, p.Y);
		if (p.X > minX && p.Y < maxY - 1)
			yield return (p.X - 1, p.Y + 1);
		if (p.Y < maxY - 1)
			yield return (p.X, p.Y + 1);
		if (p.X < maxX - 1 && p.Y < maxY - 1)
			yield return (p.X + 1, p.Y + 1);
	}

	public static int Part1(IEnumerable<string> input) {
		List<string> l = [.. input];
		int maxX = l[0].Length;
		int maxY = l.Count;
		return GetGridRange(0, 0, maxX, maxY).Where(p => l[p.Y][p.X] == '@').Count(p => GetNeighbors(p, 0, 0, maxX, maxY).Count(n => l[n.Y][n.X] == '@') < 4);
	}

	public static int Part2(IEnumerable<string> input) {
		List<string> l = [.. input];
		int maxX = l[0].Length;
		int maxY = l.Count;
		IEnumerable<Point> rollsToRemove;
		int totalRollsRemoved = 0;
		while ((rollsToRemove = [.. GetGridRange(0, 0, maxX, maxY).Where(p => l[p.Y][p.X] == '@').Where(p => GetNeighbors(p, 0, 0, maxX, maxY).Count(n => l[n.Y][n.X] == '@') < 4)]).Any()) {
			foreach (Point p in rollsToRemove) {
				l[p.Y] = l[p.Y][..p.X] + '.' + l[p.Y][(p.X + 1)..];
				++totalRollsRemoved;
			}
		}
		return totalRollsRemoved;
	}
}
