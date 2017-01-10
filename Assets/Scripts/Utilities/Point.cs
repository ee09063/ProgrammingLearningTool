using UnityEngine;
using System.Collections;

public class BoardPoint
{
	private float _x;
	private float _z;

	public BoardPoint(float x, float z)
	{
		_x = x;
		_z = z;
	}

	public float getX()
	{
		return _x;
	}

	public float getZ()
	{
		return _z;
	}
}
