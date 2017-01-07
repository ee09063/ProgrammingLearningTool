using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject MsgPanel;
    public GameObject BuildModePanel;
    public Text MenuName;

    public Button[] ButtonsToDeactivate;

    public void OnQuit()
    {
        LevelManager.QuitGame();
    }

    public void OnToggleBuildMode()
    {
        LevelManager.ToggleBuildMode(BuildModePanel);

        foreach (Button button in ButtonsToDeactivate)
        {
            button.interactable = !button.interactable;
        }
    }
        
    public void OnLostHover(Selectable target)
    {
        if (MenuName == null)
        {
            Debug.LogError("MenuManager.cs -- Menu Name is null and should not be");
            return;
        }

        MenuName.text = "Menu";
       
        if(target)
            target.OnDeselect(null);
    }

    public void OnHover(Selectable target)
    {
        if (MenuName == null)
        {
            Debug.LogError("MenuManager.cs -- Menu Name is null and should not be");
            return;
        }

        MenuName.text = target.name;
    }
}
