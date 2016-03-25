using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    public bool canAttack = false;
    public float speed = 10f;

    private GameObject playerGO;
    private Transform target;

	// Use this for initialization
	void Start () {

        playerGO = GameObject.FindGameObjectWithTag("Player");
        target = playerGO.transform;

	}
	
	// Update is called once per frame
	void Update () {

        if(canAttack == true && playerGO != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canAttack = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.position = transform.position;

            //gameObject.AddComponent<Rigidbody2D>().AddForce(new Vector2(-target.transform.position.x, -target.transform.position.y));
            
        }
    }
}
