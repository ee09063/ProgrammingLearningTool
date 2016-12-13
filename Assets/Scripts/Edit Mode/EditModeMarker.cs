using UnityEngine;
using System.Collections;

public class EditModeMarker : MonoBehaviour
{
    public Renderer rend;
    private bool _active;

    public bool Active
    {
        get
        {
            return _active;
        }
    }

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
    }

    private void ToggleMeshRenderer(bool mode)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = mode;
    }

    void OnMouseEnter()
    {
        if (EditModeManager.EditMode && !_active)
        {
            ToggleMeshRenderer(true);
        }
    }

    void OnMouseExit()
    {
        if (EditModeManager.EditMode && !_active)
        {
            ToggleMeshRenderer(false);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked on marker");
        ToggleMeshRenderer(true);
        _active = true;
    }
}
