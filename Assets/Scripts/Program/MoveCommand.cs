using UnityEngine;
using System.Collections;

public class MoveCommand : Command
{
	public enum Direction
	{
		MOV_FWD,
		MOV_BWD
	}

	private Direction _direction;
	private int _distance;

	public MoveCommand (Direction direction)
	{
		_direction = direction;
	}

	public IEnumerator Execute (GameObject gameObj)
	{
		switch (_direction) {
		case Direction.MOV_FWD:
			{
				_distance = 1;	
			}
			break;
		case Direction.MOV_BWD:
			{
				_distance = -1;
			}
			break;
		}

		gameObj.transform.Translate (Vector3.right * _distance);

		return null;
	}
}