using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {
	private float _fixedAngle = 3f;
	private float _time = 0.015f;
	private float _rotAngle = 90f;

	public void moveCube()
	{
		StartCoroutine (moveRoutine ());
	}

	private IEnumerator moveRoutine()
	{
		float angle = 0;

		Vector3 pivot = getPivotPoint(transform.position);

		for (int i = 0; i < 2; i++) {
			while (angle < _rotAngle) {
				angle += _fixedAngle;
				transform.RotateAround (pivot, Vector3.forward, -_fixedAngle);
				yield return new WaitForSeconds (_time);
			}
			angle = 0;
			pivot = getPivotPoint (transform.position);
		}

		Program.currentCommandOver = true;
	}

	public void rotateCube(float angle)
	{
		StartCoroutine (rotateRoutine (angle));
	}

	private IEnumerator rotateRoutine(float angle)
	{
		Debug.Log ("ROTATE ROUTINE");
		float totalAng = 0;

		if (angle < 0) {
			while (totalAng > angle) {
				totalAng -= _fixedAngle;
				Debug.Log (totalAng);
				transform.Rotate (new Vector3(0f, -_fixedAngle, 0f));
				yield return new WaitForSeconds (_time);
			}
		} else if(angle > 0){
			while (totalAng < angle) {
				totalAng += _fixedAngle;
				Debug.Log (totalAng);
				transform.Rotate (new Vector3(0f, _fixedAngle, 0f));
				yield return new WaitForSeconds (_time);
			}
		}

		Program.currentCommandOver = true;

	}

	private Vector3 getPivotPoint(Vector3 position)
	{
		return new Vector3 (position.x + 0.25f, 0, position.z); 
	}
}
