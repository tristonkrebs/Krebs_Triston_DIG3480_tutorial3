using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text ScoreText;
	private int score;
	public Text RestartText;
	public Text GameOverText;
	public Text winText;

	private bool gameOver;
	private bool Restart;


	void Start()
	{
		gameOver = false;
		Restart = false;
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves());
		RestartText.text = "";
		GameOverText.text = "";
		winText.text = "";

	}

	private void Update()
	{
		if (Restart)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				SceneManager.LoadScene("main");
			}
		}
		if (Input.GetKey("escape"))
			Application.Quit();
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];

				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (gameOver)
			{
				RestartText.text = "Press Q for restart";
				Restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore()
	{
		ScoreText.text = "Points: " + score;
		if (score >= 100)
		{
			winText.text = "Game Created By Triston Krebs";
			gameOver = true;
			Restart = true;
		}
	}
	public void GameOver ()
	{
		GameOverText.text = "Game Over!";
		gameOver = true;
	}


}