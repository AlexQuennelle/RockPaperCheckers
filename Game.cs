using Raylib_cs;

namespace RockPaperCheckers;

internal class Game
{
	public void Run()
	{
		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Raylib.ClearBackground(new(100, 149, 237, 255));
			Raylib.EndDrawing();
		}
	}
}