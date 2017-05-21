using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ForestManager : MonoBehaviour {
	// this entire script is taken from a 2D rogue-like tutorial on Unity's site
	// [https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial]

	[Serializable]
	public class Count {
		public int minimum;
		public int maximum;

		public Count (int min, int max) {
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 20;
	public int rows = 20;
	public Count obstacleCount = new Count (20,80);
	//public Count enemyCount = new Count (10, 15);
	//public GameObject[] enemyTiles;
	public GameObject[] floorTiles;
	public GameObject[] obstacleTiles;
	public GameObject[] outerWallTiles;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3> ();

	void InitializeList (){ // initialize grid positions
		gridPositions.Clear ();

		for (int x = 2; x < columns*2; x+=2) {
			for (int y = 2; y < rows*2; y+=2) { 
				gridPositions.Add (new Vector3 (x, y, -2f));

				//skip several tiles in the middle of the forest so that there will always be a clear path to the treehouse
				if ((x == columns || x == (columns + 2)) && y <= rows+2)
					gridPositions.Remove (new Vector3 (x, y, -2f));
			}
		}
	}

	void ForestSetUp () {
		boardHolder = new GameObject ("ForestMap").transform;
		GameObject toInstantiate;

		// generate a random floor
		for (int x = -8; x < ((columns + 5) * 2); x += 2) {
			for (int y = -8; y < ((rows + 5) * 2); y += 2) {
				toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardHolder);
			}
		}

		// generate random outer-walls
		for (int x = -8; x < ((columns + 5) * 2); x += 2) {
			for (int y = -8; y < ((rows + 5) * 2); y += 2) {
				if (x <= -2 || x >= (columns * 2) || y <= -2 || y >= (rows * 2)) {
					if ((x != columns && x != (columns + 2)) || y > rows + 2) { // leave a gap to leave the forest through
						toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
						GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, -2f), Quaternion.identity) as GameObject;
						instance.transform.SetParent (boardHolder);
					}
				}
			}
		}

	}

	Vector3 RandomPosition () { // pick a random available position in the grid, then make it unavailable
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	/* pre: tileArray refers to an array of GameObjects, min and max delineate a range of integers
	 * post: pick a number at random between min and max
			 randomly place that many items from tileArray (randomly selecting which tiles to place) */
	void LayoutObjectAtRandom (GameObject[] tileArray, int min, int max) {
		int objectCount = Random.Range (min, max + 1);

		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosition = RandomPosition ();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosition, Quaternion.identity);
		}
	}

	public void SetupScene () {
		ForestSetUp ();
		InitializeList ();
		LayoutObjectAtRandom (obstacleTiles, obstacleCount.minimum, obstacleCount.maximum);

		//int enemyCount = (int)Mathf.Log (level, 2f);
		//LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
	}
}