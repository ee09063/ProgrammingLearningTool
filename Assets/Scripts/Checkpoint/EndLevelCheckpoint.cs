using UnityEngine;
using UnityEditor;
using System.Collections;

public class EndLevelCheckpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForEndOfMovement());
        }
    }

    private IEnumerator WaitForEndOfMovement()
    {
        Debug.Log("asdasds");
        while (!Program.currentCommandOver)
        {
            Debug.Log(Program.currentCommandOver);
            yield return new WaitForSeconds(0.25f);
        }

        if (EditorUtility.DisplayDialog("LEVEL COMPLETE", "Congratulations! You have completed the level!", "Restart", "Continue"))
        {   
            LevelManager.RestartLevel();
        }

        yield break;
    }
}
