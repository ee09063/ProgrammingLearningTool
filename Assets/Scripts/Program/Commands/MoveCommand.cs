using UnityEngine;
using System;
using System.Collections;

public class MoveCommand : Command
{
	public enum Direction
	{
		FWD,
		BWD
	}

	private Direction _direction;
	private int _distance;
	private static int _numberOfArgs = 1;

	public MoveCommand (Direction direction)
	{
		_direction = direction;
	}

	public IEnumerator Execute (GameObject gameObj)
	{
		Vector3 pos = gameObj.transform.position;

		switch (_direction) {
		case Direction.FWD:
			{
				_distance = 1;	
			}
			break;
		case Direction.BWD:
			{
				_distance = -1;
			}
			break;
		}

		//gameObj.transform.Translate (Vector3.right * _distance);
		gameObj.GetComponent<CubeBehaviour>().moveCube();

		return null;
	}

	public static bool validateArgs(string args)
	{
		Debug.Log (args);
		string[] sArgs = args.Split (',');
		return sArgs.Length == _numberOfArgs && isArgInEnum(args);
	}

	public static string getArgsError()
	{
		return "move() takes 1 argument, MOV_FWD or MOV_BWD";
	}

	private static bool isArgInEnum(string arg)
	{
		return arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.FWD))
			|| arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.BWD));
	}
}