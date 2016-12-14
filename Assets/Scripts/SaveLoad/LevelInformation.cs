using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LevelInformation
{
    public List<WallInformation> LevelInfo;

    public LevelInformation()
    {
        LevelInfo = new List<WallInformation>();
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            if (wall.GetComponent<Marker>().Active)
            {
                LevelInfo.Add(new WallInformation(wall));
            }
        }
    }
}
