using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSighted : MonoBehaviour {

    public List<GameObject> enemies;

	private GameController gameController;
    private Enemies archerScript;


	void Awake(){
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
    void Start()
    {
		
        enemies = new List<GameObject>();

        //Debug.Log(transform.GetChild(0).gameObject.transform.childCount);
		/*
        int i = 0;
        for(i = 0; i < transform.GetChild(0).gameObject.transform.childCount; i++)
        {

            enemies.Add(transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
        } */
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Collider working.");

		if(other.tag == "Cart" )
        {

          //  EnemyActive();
			gameController.inZone = true;

           // Debug.Log("Player Collided");
        }
	}

	void OnTriggerExit(Collider other)
	{
		
		Debug.Log("Collider working.");
		
		if(other.tag == "Cart" )
		{
			
			//  EnemyActive();
			gameController.inZone = false;
			
			// Debug.Log("Player Collided");
		}
	}
		

    void EnemyActive()
    {
        int i = 0;

        Debug.Log("Setting Enemy active");

        for (i = 0; i < enemies.Count; i++){

            
            archerScript = enemies[i].GetComponent<Enemies>();

            archerScript.playerSighted = true;

        }
    }
		
}
