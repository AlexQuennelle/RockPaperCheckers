using System.Numerics;

namespace RockPaperCheckers;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		Game rpc = new(new Point(5, 7), 100);

		rpc.Run();
	}
}

internal struct Point(int x = 0, int y = 0)
{
	public int X = x;
	public int Y = y;

	public static implicit operator Vector2(Point p) => new(p.X, p.Y);
	public static explicit operator Point(Vector2 vec)
	{
		return new((int)vec.X, (int)vec.Y);
	}
}