using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour
{
    protected bool _active;

    public bool Active
    {
        get
        {
            return _active;
        }
        set
        {
            _active = value;
        }
    }

    protected void Awake()
    {
        ToggleMeshRenderer(false);
        ToggleColor(false);
    }

    public void ToggleColor(bool mode)
    {       
        gameObject.GetComponent<Renderer>().material.color = mode ? Color.red : Color.white; 
    }

    public void ToggleMeshRenderer(bool mode)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = mode;
    }

    void OnMouseOver()
    {
        if (BuildModeManager.BuildMode && !_active)
        {
            ToggleColor(true);
        }
    }

    void OnMouseExit()
    {
        if (BuildModeManager.BuildMode && !_active)
        {
            ToggleColor(false);
        }
    }

    protected virtual void OnMouseDown()
    {
        _active = !_active;
        ToggleColor(_active);
    }
}
