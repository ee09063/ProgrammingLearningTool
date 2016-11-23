using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MsgPanel;
    public Text MenuName;

    public void OnLoadLevel()
    {
        LevelManager.LoadLevel();
    }

    public void OnRestartLevel()
    {
        LevelManager.RestartLevel();
    }

    public void OnQuit()
    {
        LevelManager.QuitGame();
    }

    public void OnToggleMsgPanel()
    {
        LevelManager.ToggleMsgPanel(MsgPanel);
        OnMsgConsoleHover();
    }
        
    public void OnLostHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "MENU";
        }
    }

    public void OnChangeCameraHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "CHANGE CAMERA";
        }
    }

    public void OnCodeEditorHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "WRITE SOME CODE";
        }
    }

    public void OnLoadLevelHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "LOAD LEVEL";
        }
    }

    public void OnRestartLevelHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "RESTART LEVEL";
        }
    }

    public void OnQuitHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "QUIT TO MAIN MENU";
        }
    }

    public void OnMsgConsoleHover()
    {
        if (MenuName != null)
        {
            if (GetComponent<MenuManager>().MsgPanel.GetComponent<SlidePanel>().Visible)
            {
                MenuName.text = "CLOSE MESSAGE PANEL";
            }
            else
            {
                MenuName.text = "OPEN MESSAGE PANEL";
            }
        }
    }
}
