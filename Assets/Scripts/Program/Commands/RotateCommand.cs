using UnityEngine;
using System.Collections;

public class RotateCommand : Command {

	private float _angle;
	private static int _numberOfArgs = 1;

	public RotateCommand (float angle)
	{
		_angle = angle;
	}

	public IEnumerator Execute(GameObject gameObj)
	{
        MessageListController.AddMessageToList(new Message("Information", _angle < 0 ? "Turning Left" : "Turning Right"));
        gameObj.GetComponent<CubeBehaviour>().rotateCube(_angle);
		return null;
	}

	public static bool validateArgs(string args)
	{
		string[] sArgs = args.Split (',');
		int number;
		return sArgs.Length == _numberOfArgs && int.TryParse(args, out number);
	}
}
