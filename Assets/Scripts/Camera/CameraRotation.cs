using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{

    public GameObject target;

    void Update()
    {
        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.right * Time.deltaTime);
    }

}
