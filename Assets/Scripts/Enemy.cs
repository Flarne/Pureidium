using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject enemyDeathFX;
	[SerializeField] Transform parent;

	[SerializeField] int scorePerHit = 12;

	ScoreBoard scoreBoard;

	void Start()
	{
		AddBoxCollider();
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}

	private void AddBoxCollider()
	{
		Collider colliderOnEnemy = gameObject.AddComponent<BoxCollider>();
		colliderOnEnemy.isTrigger = false;
	}

	private void OnParticleCollision(GameObject other)
	{
		scoreBoard.ScoreHit(scorePerHit);
		GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
	}
}
