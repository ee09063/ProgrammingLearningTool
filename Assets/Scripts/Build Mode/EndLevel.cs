using UnityEngine;
using UnityEditor;
using System.Collections;

public class EndLevel : Marker
{

    void Start()
    {
        base.Start();
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
