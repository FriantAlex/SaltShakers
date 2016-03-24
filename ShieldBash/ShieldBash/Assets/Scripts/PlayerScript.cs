using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int health = 3;
    public bool collided = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        
        Debug.Log("It hurts!");

        if (other.collider.tag == "Damage")
        {
            health--;

            collided = true;

            if (health == 0)
            {
                Destroy(gameObject);
            }

        }

    }
}
