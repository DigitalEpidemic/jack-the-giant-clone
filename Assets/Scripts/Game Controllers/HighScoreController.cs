using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void GoBackToMainMenu () {
		SceneManager.LoadScene ("MainMenu");
	}
}
