using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionMenu : MonoBehaviour
{
    public SlidePanel[] Panels;

    public void OnOption(SlidePanel panel)
    {
        foreach (SlidePanel pan in Panels)
        {
            pan.SetVisible(false);
        }

        panel.SetVisible(true);
    }

    public void OnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
