using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    private static List<GameObject> _walls;
    private static GameObject _player;
    private static string _currentLevel;
    private static string[] _level;

    public static string CurrentLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            _currentLevel = value;
        }
    }

    public static string[] Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }

    void Start()
    {
        _walls = new List<GameObject>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public static void LoadLevel()
    {
        ClearLevel();

        if (_level != null)
        {
            for (int y = 0; y < _level.Length; y++)
            {
                string str = _level[9 - y].Substring(1, _level[y].Length - 2);
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

    public static void RestartLevel()
    {
        LoadLevel();
    }

    private static void ClearLevel()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject wall in walls)
        {
            GameObject.Destroy(wall);
        }

        if (_player != null)
        {
            _player.GetComponent<RuntimeScriptable>().ResetTransform();
        }
        else
        {
            Debug.Log("LevelManager.cs -- _player is null and should not be");
        }
    }

    public static void QuitGame()
    {

    }
}
