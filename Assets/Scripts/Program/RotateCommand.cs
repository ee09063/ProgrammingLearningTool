using UnityEngine;
using System.Collections;

public class RotateCommand : Command {
	private float _angle;

	public RotateCommand (float angle)
	{
		_angle = angle;
	}

	public IEnumerator Execute(GameObject gameObj)
	{
		gameObj.transform.Rotate(new Vector3(0, _angle, 0));

		return null;
	}

}
