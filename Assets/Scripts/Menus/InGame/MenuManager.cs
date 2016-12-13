using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MsgPanel;
    public GameObject BuildModePanel;
    public Text MenuName;

    public void OnLoadLevel()
    {
        LevelManager.LoadLevel();
    }

    public void OnSaveLevel()
    {

    }

    public void OnLoadScript()
    {
        LevelManager.LoadScript();
    }

    public void OnSaveScript()
    {
        LevelManager.SaveScript();
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

    public void OnToggleBuildMode()
    {
        LevelManager.ToggleBuildMode(BuildModePanel);
        OnEditModeHover();
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

    public void OnSaveLevelHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "Save Level";
        }
    }

    public void OnSaveScriptHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "SAVE SCRIPT";
        }
    }

    public void OnLoadScriptHover()
    {
        if (MenuName != null)
        {
            MenuName.text = "LOAD SCRIPT";
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

    public void OnEditModeHover()
    {
        if (MenuName != null)
        {
            if (EditModeManager.EditMode)
            {
                MenuName.text = "CLOSE BUILD MODE";
            }
            else
            {
                MenuName.text = "OPEN BUILD MODE";
            }
        }
    }

    public void OnMsgConsoleHover()
    {
        if (MenuName != null)
        {
            if (MsgPanel != null)
            {
                if (MsgPanel.GetComponent<SlidePanel>().Visible)
                {
                    MenuName.text = "CLOSE MESSAGE PANEL";
                }
                else
                {
                    MenuName.text = "OPEN MESSAGE PANEL";
                }
            }
            else
            {
                Debug.LogError("MenuManager.cs -- MsgPanel is null and should not be");
            }
        }
    }
}
