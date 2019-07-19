using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject enemyDeathFX;
	[SerializeField] Transform parent;

	void Start()
	{
		Collider colliderOnEnemy = gameObject.AddComponent<BoxCollider>();
		colliderOnEnemy.isTrigger = false;
	}

	private void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
	}
}
