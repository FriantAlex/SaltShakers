using UnityEngine;
using System.Collections;

public class Ricochet : MonoBehaviour {

	public LayerMask collisionMask;

	public Transform transform; // projectile transform
	public float speed; //movement speed
	public float rotSpeed; //rotation speed


	// Use this for initialization
	void Start () {
	
		transform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

		//move object forward
		transform.Translate (Vector3.right * speed * Time.deltaTime);

        
		Ray2D ray = new Ray2D (transform.position, transform.forward);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1, collisionMask);

		if (hit) {

			Vector3 reflectDir = Vector3.Reflect (hit.point, hit.normal);

			float rot =  Mathf.Atan2(reflectDir.y,reflectDir.x) * Mathf.Rad2Deg;

            //transform.eulerAngles = new Vector3 (0, rot, 0);

            var targetRot = Quaternion.AngleAxis(rot, Vector3.forward);
            transform.rotation = targetRot;
		}
	}


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.forward);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.parent = playerGO.transform;
            transform.position = this.transform.position;
            this.speed = 0;
        }
    }
}
