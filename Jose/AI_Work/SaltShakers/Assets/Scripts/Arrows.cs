using UnityEngine;
using System.Collections;

public class Arrows : MonoBehaviour {

    public float speed;
    private Vector2 _direction;
    public bool isReady;
    private GameObject playerGO;

    void Awake()
    {

        speed = 55f;
        isReady = false;
    }


    // Use this for initialization
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (isReady == true)
        {
            Vector2 position = transform.position;

            position += _direction * speed * Time.deltaTime;

            transform.position = position;

        }



    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;

        isReady = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ArrowChange!");
        if (other.collider.tag == "Player")
        {
            //SetDirection(this.transform.localPosition);
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.transform.parent = playerGO.transform;
            this.GetComponent<Rigidbody2D>().isKinematic = true;
            transform.position = this.transform.position;
            this.speed = 0;
        }

        if(other.collider.tag == "Shield")
        {
            Destroy(this.gameObject);
        }
    }
}
