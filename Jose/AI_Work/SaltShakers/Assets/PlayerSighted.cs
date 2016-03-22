using UnityEngine;
using System.Collections;

public class PlayerSighted : MonoBehaviour {

    public GameObject archer;
    private Enemies archerScript;

    void Start()
    {
        archer = GameObject.FindGameObjectWithTag("Enemy");
        archerScript = archer.GetComponent<Enemies>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Collider working.");

        if(other.tag == "Player")
        {

            archerScript.playerSighted = true;

            Debug.Log("Player Collided");
        }

    }
}
