using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame () {
		SceneManager.LoadScene ("Gameplay");
	}

	public void HighScoreMenu () {
		SceneManager.LoadScene ("HighScore");
	}

	public void OptionsMenu () {
		SceneManager.LoadScene ("OptionsMenu");
	}

	public void QuitGame () {
		Application.Quit ();
	}

	public void MusicButton () {
	}

} // MainMenuController
