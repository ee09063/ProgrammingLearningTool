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
	private ObstacleChecker _obsChecker;

	public MoveCommand (Direction direction)
	{
		_direction = direction;
		_obsChecker = new ObstacleChecker ();
		_obsChecker.Initialize ();
	}

	public IEnumerator Execute (GameObject gameObj)
    {
        bool forward = false;

        if (_direction.Equals(Direction.FWD))
            forward = true;

        Vector3 curr = gameObj.transform.position;

        MessageListController.AddMessageToList(new Message("Information", forward ? "Moving Forward" : "Moving Backwards"));

        if (!_obsChecker.checkWall(curr, gameObj.transform.forward))
        {
            gameObj.GetComponent<CubeBehaviour>().moveCube(forward);
        }

        return null;
    }

	private static bool isArgInEnum(string arg)
	{
		return arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.FWD))
			|| arg.ToUpper ().Equals (Enum.GetName (typeof(Direction), Direction.BWD));
	}
}