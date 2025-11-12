using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private Vector2Int _boardDims = new(5,5);
	public Vector2Int BoardDimensions { get { return _boardDims; } }

	private int[,] _grid;
	public ref readonly int[,] Grid => ref _grid;

	public void OnValidate()
	{
		_boardDims = new(
			Mathf.Max(_boardDims.x, 1),
			Mathf.Max(_boardDims.y, 1)
		);
		_grid = new int[_boardDims.x, _boardDims.y];
	}

}