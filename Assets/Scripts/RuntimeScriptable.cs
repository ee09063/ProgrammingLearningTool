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
		Compiler compiler = new Compiler ();
		_program = compiler.Compile (code);
		if (_program != null) {
			StartCoroutine (_program.Run (gameObject));
		}
	}

    public void ResetTransform()
	{
		transform.position = _startPosition;
		transform.rotation = _startRotation;
	}
}
