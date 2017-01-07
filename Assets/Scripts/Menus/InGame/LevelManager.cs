using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static void QuitGame()
    {
       SceneManager.LoadScene("MainMenu");
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
