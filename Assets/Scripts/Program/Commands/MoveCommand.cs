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
	private static int _numberOfArgs = 1;

	public MoveCommand (Direction direction)
	{
		_direction = direction;
	}

	public IEnumerator Execute (GameObject gameObj)
	{
		bool forward = false;
		if (_direction.Equals (Direction.FWD))
			forward = true;
		gameObj.GetComponent<CubeBehaviour>().moveCube(forward);

		return null;
	}

	public static bool validateArgs(string args)
	{
		if (args != null) {
			string[] sArgs = args.Split (',');
			return sArgs.Length == _numberOfArgs && isArgInEnum (args);
		}

		return false;
	}

	public static string getArgsError()
	{
		return "The move function takes 1 of 2 arguments -> move("+Direction.FWD.ToString()+") or move("+Direction.BWD.ToString()+")";
	}

	private static bool isArgInEnum(string arg)
	{
		return arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.FWD))
			|| arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.BWD));
	}
}