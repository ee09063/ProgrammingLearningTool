using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    private string _levelSavePath = "Savegame/Levels";
    private string _scriptSavePath = "Savegame/Scripts";
    private string _currentLevel;
    private InputField _codeEditor;
    private GameObject _player;
    private string[] _level;
    private GameObject[] _walls;
    private bool _loadMode;
    private bool _scriptMode;

    public GameObject SaveLoadPanel;
    public Button SaveLoadButton;
 

    public void Start()
    {
        _currentLevel = _levelSavePath + "/level_0.txt";
        _codeEditor = GameObject.FindGameObjectWithTag("CodeEditor").GetComponent<InputField>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _walls = GameObject.FindGameObjectsWithTag("Wall");
        _player = GameObject.FindGameObjectWithTag("Player");
        SaveLoadPanel = GameObject.FindGameObjectWithTag("SaveLoadPanel");
    }

    public void setLoadMode(bool loadMode)
    {
        _loadMode = loadMode;
    }

    public void setScriptMode(bool scriptMode)
    {
        _scriptMode = scriptMode;
    }

    public void OpenSaveLoadPanel()
    {
        string mode = _loadMode ? "Load" : "Save";
        string type = _scriptMode ? "Script" : "Level";
        string title = mode + " " + type;

        SaveLoadButton.GetComponentInChildren<Text>().text = mode;
        SaveLoadPanel.GetComponentInChildren<Text>().text = title;
        SaveLoadPanel.GetComponentInChildren<InputField>().text = "";
        SaveLoadPanel.GetComponentInChildren<InputField>().Select();
        SaveLoadPanel.GetComponentInChildren<InputField>().ActivateInputField();
        SaveLoadPanel.GetComponent<SlidePanel>().SetVisible(true);
    }
        
    public void SaveOrLoad(Text text)
    {
        if (_loadMode)
        {
            if (_scriptMode)
            {
                LoadScript(text);
            }
            else
            {
                LoadLevel(text);    
            }
        }
        else
        {
            if (_scriptMode)
            {
                SaveScript(text);
            }
            else
            {
                SaveLevel(text);    
            }
        }
    }

    public void SaveLevel(Text text)
    {
        string path = _levelSavePath + "/" + text.text + ".txt"; //= EditorUtility.SaveFilePanel("Save Script", _levelSavePath, "level.txt", "txt");

        if (path.Length == 0)
        {
            return;
        }
    
        if (!Path.GetExtension(path).Equals(".txt"))
        {
            return;
        }

        //clean the file
        File.WriteAllText(path, "");

        var levelInfo = new LevelInformation();

        foreach (WallInformation wall in levelInfo.LevelInfo)
        {
            File.AppendAllText(path, string.Format("{0} {1} {2} {3} \n", wall.x, wall.y, wall.z, wall.rotation));
        }
    }

    public void LoadLevel(Text text)
    {
        string path = _levelSavePath + "/" + text.text + ".txt";// = EditorUtility.OpenFilePanel("Load Level", _leve    lSavePath, "txt");

        if (path.Length == 0)
        {
            return;
        }

        if (!Path.GetExtension(path).Equals(".txt"))
        {
            return;
        }

        _currentLevel = path;
        CreateLevel(path);
    }

    public void SaveScript(Text text)
    {
        string path = _scriptSavePath + "/" + text.text + "";// = EditorUtility.SaveFilePanel("Save Script", _scriptSavePath, "script.txt", "txt");

        if (path.Length == 0)
        {
            return;
        }

        if (!Path.GetExtension(path).Equals(".txt"))
        {
            return;
        }

        File.WriteAllText(path, _codeEditor.text);
    }

    public void LoadScript(Text text)
    {
        string path = _scriptSavePath + "/" + text.text + ".txt"; // = EditorUtility.OpenFilePanel("Load Script", _scriptSavePath, "txt");
       
        if (path.Length == 0)
        {
            return;
        }

        if (!Path.GetExtension(path).Equals(".txt"))
        {
            return;
        }

        _codeEditor.text = "";

        foreach (string str in File.ReadAllLines(path))
        {
            _codeEditor.text += str + "\n";
        }
    }

    public void RestartLevel()
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

    private void ClearLevel()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wall in walls)
        {
            Marker wallMarker = wall.GetComponent<Marker>();
            wallMarker.Active = false;
            wallMarker.ToggleMeshRenderer(false);
        }

        if (_player != null)
        {
            _player.GetComponent<RuntimeScriptable>().ResetTransform();
        }
        else
        {
            Debug.LogError("LevelManager.cs -- _player is null and should not be");
        }
    }

    private void CreateLevel(string path)
    {
        _level = File.ReadAllLines(path);

        ClearLevel();

        if (_level == null)
        {
            return;
        }

        foreach (string wallInfo in _level)
        {
            string[] info = wallInfo.Split(null);

            float x = float.Parse(info[0]);
            float y = float.Parse(info[1]);
            float z = float.Parse(info[2]);
            float rot = float.Parse(info[3]);
           
            foreach (GameObject wall in _walls)
            {
                if (AlmostEqual(wall.transform.position, new Vector3(x, y, z), 0.1f)
                    && AlmostEqualF(wall.transform.rotation.eulerAngles.y, rot, 0.1f))
                {
                    Marker wallMarker = wall.GetComponent<Marker>();
                    wallMarker.Active = true;
                    wallMarker.ToggleMeshRenderer(true);
                    wallMarker.ToggleColor(true);
                }
            }
        }
    }

    public bool AlmostEqual(Vector3 v1, Vector3 v2, float precision)
    {
        bool equal = true;
        if (Mathf.Abs (v1.x - v2.x) >= precision) equal = false;
        if (Mathf.Abs (v1.y - v2.y) >= precision) equal = false;
        if (Mathf.Abs (v1.z - v2.z) >= precision) equal = false;
        return equal;
    }

    public bool AlmostEqualF(float f1, float f2, float precision)
    {
        bool equal = true;
        if (Mathf.Abs (f1 - f2) >= precision) equal = false;
        return equal;
    }
}
