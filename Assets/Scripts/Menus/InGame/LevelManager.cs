using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static List<GameObject> _walls;
    private static GameObject _player;
    private static InputField _codeEditor;
    private static string _currentLevel;
    private static string[] _level;

    void Start()
    {
        _walls = new List<GameObject>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _currentLevel = "Assets/SaveLoadFiles/Levels/level_0.txt";
        _codeEditor = GameObject.FindGameObjectWithTag("CodeEditor").GetComponent<InputField>();
    }

    public static void LoadLevel()
    {
        string path = EditorUtility.OpenFilePanel("Load Level", "Assets/SaveLoadFiles/Levels", "txt");
        if (path.Length != 0)
        {
            if (Path.GetExtension(path).Equals(".txt"))
            {
                _currentLevel = path;
                CreateLevel(path);
            }
        }
    }

    public static void RestartLevel()
    {
        if (_currentLevel != null)
        {
            CreateLevel(_currentLevel);
        }
        else
        {
            Debug.LogError("LevelManager.cs -- _currentLevel is null and should not be");
        }
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

    private static void CreateLevel(string path)
    {
        _level = File.ReadAllLines(path);

        ClearLevel();

        if (_level != null)
        {
            for (int y = 0; y < _level.Length; y++)
            {
                string str = _level[6 - y].Substring(1, _level[y].Length - 2);
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

    public static void SaveScript()
    {
        string path = EditorUtility.SaveFilePanel("Save Script", "Assets/SaveLoadFiles/Scripts", "script.txt", "txt");
        if (path.Length != 0)
        {
            if (Path.GetExtension(path).Equals(".txt"))
            {
                File.WriteAllText(path, _codeEditor.text);
            }
        }
    }

    public static void LoadScript()
    {
        string path = EditorUtility.OpenFilePanel("Load Script", "Assets/SaveLoadFiles/Scripts", "txt");
        if (path.Length != 0)
        {
            if (Path.GetExtension(path).Equals(".txt"))
            {
                _codeEditor.text = "";
                foreach(string str in File.ReadAllLines(path))
                {
                    _codeEditor.text += str + "\n";
                }
            }
        }
    }

    public static void QuitGame()
    {
        if (EditorUtility.DisplayDialog("QUIT", "Are you sure you want to return to the Main Menu?", "Yes", "No"))
        {   
            SceneManager.LoadScene("MainMenu");
        }
    }

    public static void ToggleMsgPanel(GameObject MsgPanel)
    {
        bool visible = MsgPanel.GetComponent<SlidePanel>().Visible;
        MsgPanel.GetComponent<SlidePanel>().SetVisible(!visible);
    }
}
