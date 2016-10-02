using UnityEngine;
using System.Collections;

public class RuntimeScriptable : MonoBehaviour {

	private Program _program;
	private Vector3 _startPosition;
	private Quaternion _startRotation;

	void Start () {
		_startPosition = transform.position;
		_startRotation = transform.rotation;
	}
	
	public void CompileAndRun(string code)
	{
		StopAllCoroutines ();
		_program = Compiler.Compile (code);
		StartCoroutine (_program.Run (gameObject));
	}

	private void ResetTransform()
	{
		transform.position = _startPosition;
		transform.rotation = _startRotation;
	}
}
