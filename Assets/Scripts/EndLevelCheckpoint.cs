using UnityEngine;
using UnityEditor;
using System.Collections;

public class EndLevelCheckpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("THE PLAYER HAS REACHED THE END OF THE LEVEL");
            /*if (EditorUtility.DisplayDialog("LEVEL COMPLETE", "Congratulations! You have completed the level!", "Restart", "Continue"))
            {   
                LevelManager.RestartLevel();
            }*/  
        }
    }
}
