﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour
{
	public GameObject explosions;
	public GameObject playerexplosion;
	public int scoreValue;
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
			Debug.Log("Cannot find 'GameController' script");

		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag== "Boundry")
			{ return;
		}
		Instantiate(explosions, transform.position, transform.rotation);
		if (other.tag == "Player")
		{
			Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		gameController.AddScore(scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
