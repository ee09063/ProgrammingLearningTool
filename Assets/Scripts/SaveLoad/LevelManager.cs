using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    private static List<GameObject> _walls;

    void Start()
    {
        _walls = new List<GameObject>();
    }

    public static void CreateLevel(string[] level)
    {
        for (int y = 0; y < level.Length; y++)
        {
            string str = level[9-y].Substring(1, level[y].Length - 2);
            for (int x = 0; x < str.Length; x++)
            {
                char ch = str[x];
                if (ch.Equals(' ')) //empty
                {

                }
                else if (ch.Equals('_')) // wall
                {
                    float x1 = (x / 2.0f) + 0.5f;
                    float y1 = y;
                    GameObject wall = Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
                    wall.transform.position = new Vector3(x1, 0.5f, y1);
                    wall.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                    _walls.Add(wall);
                }
                else if (ch.Equals('|')) // wall
                {
                    float x1 = (x / 2.0f) + 0.5f;
                    float y1 = y + 0.5f;
                    GameObject wall = Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
                    wall.transform.position = new Vector3(x1, 0.5f, y1);
                    _walls.Add(wall);
                }
            }
        }
    }
}
