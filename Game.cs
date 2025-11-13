using Raylib_cs;

namespace RockPaperCheckers;

internal class Game
{
	private readonly Point _gridSize;
	private readonly int _cellSize;
	private GamePiece?[,] _board;

	private PieceTeam _currentTurn = PieceTeam.Player1;

	public Game(Point gridSize, int cellSize)
	{
		Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
		Raylib.InitWindow(
			(gridSize.X * cellSize) + (cellSize * 3),
			gridSize.Y * cellSize,
			"Rock Paper Checkers"
		);

		_gridSize = gridSize;
		_cellSize = cellSize;

		_board = new GamePiece?[gridSize.X, gridSize.Y];
		_board[0, 0] = new(PieceTeam.Player2, PieceType.Red);
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
				int col = ((x % 2) + y) % 2 * 80 + 175;
				Raylib.DrawRectangleRec(
					new(x * _cellSize, y * _cellSize, _cellSize, _cellSize),
					new(col, col, col, 255)
				);

				if (_board[x, y] != null)
				{
					_board[x, y].Draw(_currentTurn, new(x, y), _cellSize);
				}

				int turnSide = (int)_currentTurn == 1
					? 0
					: _cellSize * (_gridSize.Y - 1);

				Raylib.DrawRectangleLinesEx(
					new(0.0f, turnSide, _gridSize.X * _cellSize, _cellSize),
					_cellSize * 0.05f,
					Color.Yellow
				);
			}
		}
	}
}