﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	// this entire script is taken from a 2D rogue-like tutorial on Unity's site
	// [https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial]
	// [https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-game-manager?playlist=17150]

	//public float levelStartDelay = 2f;
	//public float turnDelay = 0.1f;
	public static GameManager instance = null;
	public ForestManager forestScript;
	//[HideInInspector] public bool playersTurn = true;

	//private Text levelText;
	private GameObject levelImage;
	//private List<Enemy> enemies;
	//private bool enemiesMoving;
	//private bool doingSetUp;

	void Awake () {

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		//enemies = new List<Enemy> ();
		forestScript = GetComponent<ForestManager> ();
		InitGame ();
	}

	/*void OnLevelFinishedLoading (Scene scene, LoadSceneMode mode) {
		level++;
		InitGame ();
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}*/

	void InitGame() {
		//doingSetUp = true;

		//levelImage = GameObject.Find ("Level Image");
		//levelText = GameObject.Find ("Level Text").GetComponent<Text> ();
		//levelText.text = "Day " + level;
		//levelImage.SetActive (true);

		//Invoke ("HideLevelImage", levelStartDelay);

		//enemies.Clear ();
		forestScript.SetupScene ();

	}

	/*private void HideLevelImage () {
		levelImage.SetActive (false);
		//doingSetUp = false;
	}*/

	/*public void GameOver () {
		levelText.text = "After " + level + " days, you starved.";
		levelImage.SetActive (true);
		enabled = false;

	}*/

	// Update is called once per frame
	void Update () {
		/*if (playersTurn || enemiesMoving || doingSetUp)
			return;
		StartCoroutine (MoveEnemies());*/
	}

	/*public void AddEnemyToList (Enemy script) {
		enemies.Add (script);
	}*/

	/*IEnumerator MoveEnemies(){
		enemiesMoving = true;
		yield return new WaitForSeconds (turnDelay);

		/*if (enemies.Count == 0) {
			yield return new WaitForSeconds (turnDelay);
		}

		/*for (int i = 0; i < enemies.Count; i++) {
			enemies [i].MoveEnemy ();
			yield return new WaitForSeconds (enemies[i].moveTime);
		}

		playersTurn = true;
		enemiesMoving = false;

	}*/
}

