using Raylib_cs;

namespace RockPaperCheckers;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		Raylib.InitWindow(800,400,"Rock Paper Checkers");
		Game rpc = new();

		rpc.Run();

		Raylib.CloseWindow();
	}
}