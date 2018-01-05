using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private GameObject readyButton;

	[SerializeField]
	private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	void Awake () {
		MakeInstance ();
	}

	void Start () {
		Time.timeScale = 0f;
	}
	
	void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void GameOverShowPanel (int finalScore, int finalCoinScore) {
		gameOverPanel.SetActive (true);
		gameOverScoreText.text = finalScore.ToString ();
		gameOverCoinText.text = finalCoinScore.ToString ();
		StartCoroutine (GameOverLoadMainMenu ());
	}

	IEnumerator GameOverLoadMainMenu () {
		yield return new WaitForSeconds (3f);
		// SceneManager.LoadScene ("MainMenu");
		SceneFader.instance.LoadLevel ("MainMenu");
	}

	public void PlayerDiedRestartTheGame () {
		StartCoroutine (PlayerDiedRestart ());
	}

	IEnumerator PlayerDiedRestart () {
		yield return new WaitForSeconds (1f);
		// SceneManager.LoadScene ("Gameplay");
		SceneFader.instance.LoadLevel ("Gameplay");
	}

	public void SetScore (int score) {
		scoreText.text = score.ToString ();
	}

	public void SetCoinScore (int coinScore) {
		coinText.text = "x" + coinScore;
	}

	public void SetLifeScore (int lifeScore) {
		lifeText.text = "x" + lifeScore;
	}

	public void PauseGame () {
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
	}

	public void ResumeGame () {
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void QuitGame () {
		Time.timeScale = 1f;
		// SceneManager.LoadScene ("MainMenu");
		SceneFader.instance.LoadLevel ("MainMenu");
	}

	public void ReadyToStart () {
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}

	public void ShowRewardedVideo () {
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	public void HandleShowResult (ShowResult result) {
		if (result == ShowResult.Finished) {
			Debug.Log ("Video completed - Offer a reward to the player");
			if (PlayerScore.lifeCount < 2) {
				PlayerScore.lifeCount++;
				lifeText.text = "x" + PlayerScore.lifeCount;
			} else {
				Debug.Log ("Too many lives");
			}

		} else if (result == ShowResult.Skipped) {
			Debug.LogWarning ("Video was skipped - Do NOT reward the player");

		} else if (result == ShowResult.Failed) {
			Debug.LogError ("Video failed to show");
		}
	}
}
