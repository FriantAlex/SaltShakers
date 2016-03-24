using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	//is in zone
	public bool inZone = false;

	//enemis
	public int maxEnemies = 10;
	public GameObject[] enemys;
	public GameObject magePrefab;
	public GameObject rangerPrefab;

	private Patrol playerController;
	// Use this for initialization
	void Start () {

		playerController = GameObject.FindWithTag ("Cart").GetComponent<Patrol> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
		 enemys = GameObject.FindGameObjectsWithTag ("Enemy");

		if (inZone) {

			StartCoroutine (EnemyPlacer());

		}

		if (!inZone && playerController.maxPatrolSpeed == 0) {

			playerController.maxPatrolSpeed = 50;
			for(int i = 0; i < enemys.Length; i++){
				Destroy(enemys[i]);
			}

		}



	}

	IEnumerator EnemyPlacer(){

			for (int i = enemys.Length; i < 1; i++) {

				Instantiate (magePrefab, new Vector3 (81.9f, 54.1f, 0.0f), transform.rotation);
				yield return new WaitForSeconds (1);
				Instantiate (magePrefab, new Vector3 (-64.6f, 1.7f, 0.0f), transform.rotation);
				yield return new WaitForSeconds (1);
				
				magePrefab.GetComponent<Enemies> ().playerSighted = true;

				i++;
			}



	}
}
