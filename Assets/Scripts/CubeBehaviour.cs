using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour
{
    private float _fixedAngle = 3f;
    private float _time = 0.015f;
    private float _rotAngle = 90f;

    public void moveCube(bool forward)
    {
        StartCoroutine(moveRoutine(forward));
    }

    private IEnumerator moveRoutine(bool isForward)
    {
        Debug.Log("MOVE ROUTINE");
        float angle = 0;
        Vector3 fwd = transform.forward;
        Vector3 pivot;

        if (isForward && (fwd.x < -0.1f || fwd.z < -0.1f))
        {
            isForward = false;
        }
        else if (!isForward && (fwd.x < -0.1f || fwd.z < -0.1f))
        {
            isForward = true;
        }

        if (!canMove(isForward))
        {
            Program.currentCommandOver = true;
            return true;
        }

        for (int i = 0; i < 1; i++)
        {
            angle = 0;
            pivot = getPivotPoint(transform.position, fwd, isForward);
            transform.forward = fwd;
			
            Debug.Log("Pivot  "  + pivot);
            Debug.Log("Forward  " + fwd);

            Vector3 axis = fwd.z < -0.1f || fwd.z > 0.1f ? Vector3.left : Vector3.forward;
            float rotAngle = isForward ? -_fixedAngle : _fixedAngle;
			
            Debug.Log("Axis: " + axis);

            while (angle < _rotAngle)
            {
                angle += _fixedAngle;
                transform.RotateAround(pivot, axis, rotAngle);
                yield return new WaitForSeconds(_time);
            }
        }

        transform.forward = fwd;

        Program.currentCommandOver = true;
    }

    public void rotateCube(float angle)
    {
        StartCoroutine(rotateRoutine(angle));
    }

    private IEnumerator rotateRoutine(float angle)
    {
        float totalAng = 0;

        if (angle < 0)
        {
            while (totalAng > angle)
            {
                totalAng -= _fixedAngle;
                transform.Rotate(new Vector3(0f, -_fixedAngle, 0f));
                yield return new WaitForSeconds(_time);
            }
        }
        else if (angle > 0)
        {
            while (totalAng < angle)
            {
                totalAng += _fixedAngle;
                transform.Rotate(new Vector3(0f, _fixedAngle, 0f));
                yield return new WaitForSeconds(_time);
            }
        }

        Program.currentCommandOver = true;
    }

    private Vector3 getPivotPoint(Vector3 pos, Vector3 fwd, bool isForward)
    {
        float increment = isForward ? 0.25f : -0.25f;
        float newX = isApproximateTo(fwd.x, 0.0f, 0.005f) ? pos.x : (pos.x + increment) * Mathf.Abs(fwd.x);
        float newZ = isApproximateTo(fwd.z, 0.0f, 0.005f) ? pos.z : (pos.z + increment) * Mathf.Abs(fwd.z);
        return new Vector3(newX, 0.0f, newZ);
    }

    private bool canMove(bool forward)
    {
        return isInsideBounds(getFuturePosition(forward));
    }

    private Vector3 getFuturePosition(bool forward)
    {
        Vector3 pos = transform.position;
        if (forward)
        {
            return new Vector3(pos.x + 1.0f, 0, pos.z);
        }
        else
        {
            return new Vector3(pos.x - 1.0f, 0, pos.z);
        }
    }

    private bool isInsideBounds(Vector3 pos)
    {
        return pos.x >= 0.5 && pos.x <= 9.5 && pos.z >= 0.5 && pos.z <= 9.5;
    }

    private bool isApproximateTo(float f1, float f2, float tolerance)
    {
        return f1 < f2 + 0.005f && f1 > f2 - 0.005f; 
    }
}
