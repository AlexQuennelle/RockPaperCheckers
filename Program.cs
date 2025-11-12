using Raylib_cs;

namespace RockPaperCheckers;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		Raylib.InitWindow(800,400,"Rock Paper Checkers");

		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(new(100,149,237,255));
			Raylib.EndDrawing();
		}
	}
}