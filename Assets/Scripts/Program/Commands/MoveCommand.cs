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

        if (_direction.Equals(Direction.FWD))
        {
            forward = true;
        }


        MessageListController.AddMessageToList(new Message("Information", forward ? "Moving Forward" : "Moving Backwards"));

        gameObj.GetComponent<CubeBehaviour>().moveCube(forward);

        return null;
    }

	private static bool isArgInEnum(string arg)
	{
		return arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.FWD))
			|| arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.BWD));
	}
}