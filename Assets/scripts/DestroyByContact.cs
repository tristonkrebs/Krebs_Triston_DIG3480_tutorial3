using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int ScoreValue;

	private GameController gameController;

	private void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		if (gameController == null)
		{
			Debug.Log("Cannot Find Game Contoller");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == ("Boundry") || other.tag == ("Bad"))
			return;



		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		else
		{
			if (explosion != null)
			{
				Instantiate(explosion, transform.position, transform.rotation);
			}
		}

		gameController.AddScore(ScoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}