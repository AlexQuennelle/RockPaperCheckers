using Raylib_cs;

namespace RockPaperCheckers;

internal class Game
{
	private readonly Point _gridSize;
	private readonly int _cellSize;

	public Game(Point gridSize, int cellSize)
	{
		Raylib.InitWindow(
			gridSize.X * cellSize,
			gridSize.Y * cellSize,
			"Rock Paper Checkers"
		);

		_gridSize = gridSize;
		_cellSize = cellSize;
	}
	~Game()
	{
		Raylib.CloseWindow();
	}

	public void Run()
	{
		while (!Raylib.WindowShouldClose())
		{
			Raylib.BeginDrawing();
			Update();
			Draw();
			Raylib.EndDrawing();
		}
	}

	private void Update()
	{
	}
	private void Draw()
	{
		Raylib.ClearBackground(new(100, 149, 237, 255));
		for (int x = 0; x < _gridSize.X; x++)
		{
			for (int y = 0; y < _gridSize.Y; y++)
			{
				int col = ((x % 2) + y) % 2 * 255;
				Raylib.DrawRectangleRec(
					rec: new(x * 100, y * 100, 100.0f, 100.0f),
					color: new(col, col, col, 255)
				);
			}
		}
	}
}