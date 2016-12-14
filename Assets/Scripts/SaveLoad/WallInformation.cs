using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WallInformation
{
    public float x;
    public float y;
    public float z;
    public float rotation;

    public WallInformation(GameObject wall)
    {
        x = wall.transform.position.x;
        y = wall.transform.position.y;
        z = wall.transform.position.z;
        rotation = wall.transform.rotation.eulerAngles.y;
    }
}
