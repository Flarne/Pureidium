using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private void Awake()
	{
		// Singleton Pattern
		int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
		if (numMusicPlayers > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
		// Singleton Pattern ends
	}
}
