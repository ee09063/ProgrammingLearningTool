using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{

    public float speed = 100f;
    public Vector3 rot = new Vector3(15f, 15f, 15f);

    void Update()
    {
        transform.Rotate(rot, speed * Time.deltaTime);	
    }
}
