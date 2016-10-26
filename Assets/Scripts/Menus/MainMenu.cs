using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void OnStartPressed ()
	{
		SceneManager.LoadScene ("Board");
	}

	public void OnQuitPressed()
	{
		Application.Quit ();
	}
}
