using UnityEngine;
using System.Collections;

public class EndLevel : Marker
{
    private GameObject _endLevelPanel;
    private bool _activated;

    new void Start()
    {
        base.Awake();
        _endLevelPanel = GameObject.FindGameObjectWithTag("EndLevelPanel");
    }

    protected override void OnMouseDown()
    {
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("EndCheckpoint");
        foreach (GameObject mrk in checkpoints)
        {
            mrk.GetComponent<Marker>().Active = false;
            mrk.GetComponent<Marker>().ToggleColor(false);
        }

        Active = true;
        ToggleColor(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!_active || _activated)
        {
            return;
        }

        print("ENTER " + gameObject.transform.position);

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForEndOfMovement());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!_active || !_activated)
        {
            return;
        }

        print("EXIT " + gameObject.transform.position);

        if (other.gameObject.CompareTag("Player"))
        {
            _activated = false;
        }
    }

    private IEnumerator WaitForEndOfMovement()
    {
        while (!Program.currentCommandOver)
        {
            yield return new WaitForSeconds(0.25f);
        }
            
        _endLevelPanel.GetComponent<SlidePanel>().SetVisible(true);
        _activated = true;

        yield break;
    }
}
