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
		gameObj.transform.Rotate(new Vector3(0, _angle, 0));

		return null;
	}

	public static bool validateArgs(string args)
	{
		string[] sArgs = args.Split (',');
		int number;
		return sArgs.Length == _numberOfArgs && int.TryParse(args, out number);
	}
}
