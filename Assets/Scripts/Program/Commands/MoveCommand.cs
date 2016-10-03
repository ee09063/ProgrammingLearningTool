using UnityEngine;
using System;
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
	private static int _numberOfArgs = 1;

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

	public static bool validateArgs(string args)
	{
		string[] sArgs = args.Split (',');
		return sArgs.Length == _numberOfArgs && isArgInEnum(args);
	}

	public static string getArgsError()
	{
		return "move() takes 1 argument, MOV_FWD or MOV_BWD";
	}

	private static bool isArgInEnum(string arg)
	{
		return arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.MOV_FWD))
			|| arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.MOV_BWD));
	}
}