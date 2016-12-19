using UnityEngine;
using UnityEditor;
using System.Collections;

public class EndLevel : Marker
{

    void Start()
    {
        base.Start();
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
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForEndOfMovement());
        }
    }

    private IEnumerator WaitForEndOfMovement()
    {
        while (!Program.currentCommandOver)
        {
            yield return new WaitForSeconds(0.25f);
        }

        if (EditorUtility.DisplayDialog("LEVEL COMPLETE", "Congratulations! You have completed the level!", "Restart", "Continue"))
        {   
            SaveLoad.RestartLevel();
        }

        yield break;
    }
}
