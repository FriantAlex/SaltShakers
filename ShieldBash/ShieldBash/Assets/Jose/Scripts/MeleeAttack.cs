using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    public bool canAttack = false;
    public float speed = 1f;

    private GameObject playerGO;
    private Transform target;
    public float minRange = 10f;
    public float maxDistance;
    public bool chasing = false;

	// Use this for initialization
	void Start () {

        playerGO = GameObject.FindGameObjectWithTag("Player");
        target = playerGO.transform;

	}
	
	// Update is called once per frame
	void Update () {

        if(canAttack == true && playerGO != null)
        {
           

            if (chasing)
            {
                Debug.Log("Chasing");
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                
                Debug.Log("notWorking");
            }
        }
	
         if (Vector3.Distance(transform.position, target.position) < minRange)
        {
            chasing = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canAttack = true;
            chasing = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //transform.position = transform.position;

            //gameObject.AddComponent<Rigidbody2D>().AddForce(new Vector2(-target.transform.position.x, -target.transform.position.y));
            
        }
    }
}
