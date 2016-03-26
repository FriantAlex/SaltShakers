using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float health = 20;
    public bool collided = false;
    public Slider healthBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
          if(health <= 0)
        {
            Destroy(gameObject);
        }

        //healthBar.GetComponent<Slider>().value = health;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        Debug.Log("It hurts!");

        if (other.collider.tag == "Damage")
        {
            ChangeHealthAndDeath();
        }

    }

    public void ChangeHealthAndDeath()
    {
        
        health--;
        
        collided = true;

    }
}
