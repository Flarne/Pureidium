using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long this is the only script that loads a scene

public class CollisionHandler : MonoBehaviour
{

	[Tooltip("In Seconds")] [SerializeField] float levelLoadDelay = 1f;
	[Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

	void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
		deathFX.SetActive(true);
		Invoke("ReloadScene", levelLoadDelay);

		//if (other.gameObject.tag == "EnemyShip")
		//{
		//	print("You crashed into a enemy ship!!");
		//}
		//if (other.gameObject.tag == "Obstacle")
		//{
		//	print("Player triggered a Obstacle");
		//}
		//if (other.gameObject.tag == "Terrain")
		//{
		//	print("Player triggerde a terrain collider");
		//}
	}

	private void StartDeathSequence()
	{
		SendMessage("OnPlayerDeath");
	}

	private void ReloadScene()
	{
		SceneManager.LoadScene(1);
	}
}
