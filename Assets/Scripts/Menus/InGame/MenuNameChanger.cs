using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuNameChanger : MonoBehaviour
{
    public Text MenuName;
	
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
 
}
