using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public GameObject wall;

    private string[] _level;

    public void OnLoadLevel()
    {
        string path = EditorUtility.OpenFilePanel("Load Level", "Assets/Levels", "txt");
        if (path.Length != 0)
        {
            if(Path.GetExtension(path).Equals(".txt"))
            {
                _level = File.ReadAllLines(path);
                LevelManager.CreateLevel(_level);
            }
        }
    }
}
