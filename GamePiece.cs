using System.Numerics;

using Raylib_cs;

namespace RockPaperCheckers;

internal class GamePiece(PieceTeam team, PieceType type)
{
	public PieceTeam Team { get; private set; } = team;
	public PieceType Type { get; private set; } = type;

	public void Draw(PieceTeam currentTurn, Point pos, int size)
	{
		if (Team == currentTurn)
		{
			Raylib.DrawCircleV(
				(Vector2)pos * size + new Vector2(size / 2.0f, size / 2.0f),
				size * 0.9f / 2.0f,
				Color.Yellow
			);
		}
		Raylib.DrawCircleV(
			(Vector2)pos * size + new Vector2(size / 2.0f, size / 2.0f),
			size * 0.85f / 2.0f,
			GetTypeColour(Type)
		);
	}

	public static Color GetTypeColour(PieceType type) => type switch
	{
		PieceType.Red => Color.Red,
		PieceType.Green => Color.Green,
		PieceType.Blue => Color.Blue,
		_ => Color.Black,
	};
}

enum PieceType
{
	Red,
	Green,
	Blue,
}
enum PieceTeam
{
	Player1,
	Player2,
}