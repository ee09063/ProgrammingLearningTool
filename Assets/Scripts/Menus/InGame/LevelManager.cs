using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static List<GameObject> _walls;

    public BuildModeManager buildModeManager;

    void Start()
    {
        _walls = new List<GameObject>();
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

    public static void ToggleBuildMode(GameObject BuildModePanel)
    {
        bool visible = BuildModePanel.GetComponent<SlidePanel>().Visible;
        BuildModePanel.GetComponent<SlidePanel>().SetVisible(!visible);
        BuildModeManager.ToggleBuildMode();
    }
}
