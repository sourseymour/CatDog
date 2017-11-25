﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefabMelee;
	public Transform enemyPrefabRange;
	public Transform enemyPrefabAOE;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;

	public static int MinonBuild;
	public static int GateChoice;

	public WaypointScript Startpoint;
	public WaypointScript targetWaypoint;
	public GameObject minion1;
	//public GameObject SetMinonToBuild;

	public Text waveCountdownText;

	private float countdown = 5f;

	private int waveIndex= 1;

	public static float currency = 12f;

	public GameObject Orignizer;

	void Update()
	{
		if (countdown <= 0f) {
			//StartCoroutine (SpawnWave());

			countdown = timeBetweenWaves;
			currency = currency + 1;
		}

		countdown -= Time.deltaTime;

		//waveCountdownText.text = Mathf.Round(countdown).ToString ();
		waveCountdownText.text = Mathf.Round(currency).ToString();

		SpawnEnemy ();
		//StartCoroutine (SpawnWave());
	}

	//IEnumerator SpawnWave()
	//{
		//waveIndex++;
		//for (int i = 0; i < waveIndex; i++) {
			
			//yield return new WaitForSeconds (0.5f);
		
		//}

	//}

	void SpawnEnemy ()
	{

		if (MinonBuild == 1){ 
			//PlayerScript temp =
			//GameObject temp =
			GameObject temp =Instantiate (minion1, transform.position, Quaternion.identity);
			temp.AddComponent<PlayerScript>(); // you were missing the () after player script  :) 
			temp.GetComponent<PlayerScript> ().targetWaypoint = Startpoint; 
			temp.name = "minion_test";
			temp.transform.parent = Orignizer.transform; //just to see it in hirarcy + to track 
			//temp.targetWaypoint = Startpoint;
			currency = currency - 2;
			MinonBuild = 4;
	}
		if (MinonBuild == 2){
			Instantiate (enemyPrefabRange, spawnPoint.position, spawnPoint.rotation);
			currency = currency - 4;
			MinonBuild = 4;
		}

		if (MinonBuild ==3){
			Instantiate (enemyPrefabAOE, spawnPoint.position, spawnPoint.rotation);
			currency = currency - 4;
			MinonBuild = 4;
		}

		if (MinonBuild == 4) {
			return;
		}
}
	void WaitforIt ()
	{
		return;
	}

}
