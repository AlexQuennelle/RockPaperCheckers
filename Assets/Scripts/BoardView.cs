using System.Collections.Generic;
using System.Linq;

using UnityEngine;

[ExecuteInEditMode]
public class BoardView : MonoBehaviour
{
	[SerializeField]
	private Board _board;
	[SerializeField]
	private SpriteRenderer _spriteRenderer;
	[SerializeField]
	private Sprite _sprite;
	private Texture2D _tex;

	[SerializeField]
	private Vector2Int _dims = new(500,500);
	[SerializeField]
	private Vector2 _ratio;

	/// <summary>test</summary>
	public void OnValidate()
	{
		Vector2Int gridDims = _board.BoardDimensions;

		_dims = new(
			Mathf.Max(_dims.x, gridDims.x),
			Mathf.Max(_dims.y, gridDims.y)
		);
		_ratio = (Vector2)_dims / gridDims;

		_tex = new(_dims.x, _dims.y);
		List<Color> colors =
			Enumerable.Repeat<Color>(
				new(1.0f,1.0f,1.0f,1.0f),
				_dims.x * _dims.y
			).ToList();

		_tex.SetPixelData(colors.ToArray(), 1);
		List<Color> gridSquare;
		for (int x = 0; x < gridDims.x; x++)
		{
			for (int y = 0; y < gridDims.y; y++)
			{
				int gridVal = (x + 1 - y % 2) % 2;
				gridSquare =
					Enumerable.Repeat<Color>(
					new(gridVal, gridVal, gridVal, 1.0f),
					(int)_ratio.x * (int)_ratio.y
					).ToList();
				_tex.SetPixels(
					(int)(x * _ratio.x),
					(int)(y * _ratio.y),
					(int)_ratio.x,
					(int)_ratio.y,
					gridSquare.ToArray()
				);
			}
		}
		_tex.Apply();
		_sprite = Sprite.Create(
			_tex,
			new Rect(0.0f, 0.0f, _dims.x, _dims.y),
			new Vector2(0.5f, 0.5f)
		);
	}

	public void Update()
	{
		_spriteRenderer.sprite = _sprite;
	}
}