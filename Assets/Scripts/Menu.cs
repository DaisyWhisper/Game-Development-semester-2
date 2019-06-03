using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void PlayGame ()
	{
		SceneManager.LoadScene(2);
	}
	public void PlayInstructions ()
	{
		SceneManager.LoadScene(1);
	}
	public void PlayMenu ()
	{
		SceneManager.LoadScene(0);
	}
	public void QuitGame()

	{
		Debug.Log("QUIT");
		Application.Quit();        
	}
}
