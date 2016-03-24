using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSighted : MonoBehaviour {

    public List<GameObject> enemies;

    private Enemies enemyScript;
    private BouncingLaser mageAttack;

    void Start()
    {
        enemies = new List<GameObject>();

        Debug.Log(transform.GetChild(0).gameObject.transform.childCount);

        int i = 0;
        for(i = 0; i < transform.GetChild(0).gameObject.transform.childCount; i++)
        {

            enemies.Add(transform.GetChild(0).gameObject.transform.GetChild(i).gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Collider working.");

        if(other.tag == "Player")
        {

            EnemyActive();


           // Debug.Log("Player Collided");
        }

       

    }

    void EnemyActive()
    {
        int i = 0;

        Debug.Log("Setting Enemy active");

        for (i = 0; i < enemies.Count; i++){

            
            enemyScript = enemies[i].GetComponent<Enemies>();
            enemyScript.playerSighted = true;

            if (enemies[i].GetComponent<LineRenderer>() != null)
            {
                mageAttack = enemies[i].GetComponent<BouncingLaser>();
                mageAttack.ifActive = true;
            }
        }
    }
}
