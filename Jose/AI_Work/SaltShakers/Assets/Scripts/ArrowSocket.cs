using UnityEngine;
using System.Collections;
    


public class ArrowSocket : MonoBehaviour {
    public GameObject arrowGO;
    //public float shootTimer = 10f;
    public float timeElapse = 0.0f;
    public float delay = 0.0f;

    private Vector3 euler;
    private Vector3 look;

    public bool collided = false;

    private GameObject archer;
    private Enemies archerScript;
    private GameObject playerGO;
    private PlayerScript playerScript;

    private GameObject arrows;

    // Use this for initialization
    void Start () {

        //finds archer
        archer = GameObject.FindGameObjectWithTag("Enemy");
        archerScript = archer.GetComponent<Enemies>(); //grabs Enemies Script from it.

        //finds the player
        playerGO = GameObject.Find("Player");
        playerScript = playerGO.GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerGO != null)
        {
            euler = transform.eulerAngles;
            look = playerGO.transform.transform.position - this.transform.position;
            euler.z = Mathf.Atan2(look.x, look.y) * -Mathf.Rad2Deg - archer.transform.localRotation.z + 90;

            transform.eulerAngles = euler;

            collided = playerScript.collided;

            if (archerScript.playerSighted == true)
            {
                FireArrows();
            }
        }
    }

    void FireArrows()
    {
       

        if (playerGO != null && timeElapse > delay) //check if the player is still alive or in game.
        {

            arrows = (GameObject)Instantiate(arrowGO); //sets a instantiation of the ArrowsGO 

            arrows.transform.position = transform.position; // sets arrow's new position

            arrows.transform.eulerAngles = this.transform.eulerAngles;

            Vector2 direction = playerGO.transform.position - arrows.transform.position; // Check for the direction of the player(where to shoot at)
            
            //arrows.GetComponent<Arrows>().SetDirection(direction); //sets the direction of the bullet and shoots.

            

            timeElapse = 0.0f;
        }

        timeElapse += Time.deltaTime;
    }


    
}
