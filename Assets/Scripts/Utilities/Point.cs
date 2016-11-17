using UnityEngine;
using System.Collections;

public class BoardPoint
{
	private float _x;
	private float _y;

	public BoardPoint(float x, float y)
	{
		_x = x;
		_y = y;
	}

	public float getX()
	{
		return _x;
	}

	public float getY()
	{
		return _y;
	}
}
