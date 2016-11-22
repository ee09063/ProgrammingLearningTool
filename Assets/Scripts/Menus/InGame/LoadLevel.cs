using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public GameObject wall;

    private string[] _level;

    public void OnLoadLevel()
    {
        string path = EditorUtility.OpenFilePanel("Load Level", "Assets/Levels", "txt");
        if (path.Length != 0)
        {
            if (Path.GetExtension(path).Equals(".txt"))
            {
                LevelManager.CurrentLevel = path;
                _level = File.ReadAllLines(path);
                LevelManager.Level = _level;
                LevelManager.LoadLevel();
            }
        }
    }

    public void OnRestartLevel()
    {
        LevelManager.RestartLevel();
    }

    public void OnQuit()
    {
        if (EditorUtility.DisplayDialog("QUIT", "Are you sure you want to return to the Main Menu?", "Yes", "No"))
        {   
            SceneManager.LoadScene("MainMenu");
        }
    }
}
