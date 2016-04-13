﻿using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D trigger){
		levelManager = FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Lose");
	}
}
