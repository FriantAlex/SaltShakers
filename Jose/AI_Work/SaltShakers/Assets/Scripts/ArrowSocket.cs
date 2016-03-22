using UnityEngine;
using System.Collections;
    


public class ArrowSocket : MonoBehaviour {
    public GameObject arrowGO;
    public float shootTimer = 10f;
    public float timeElapse = 0.0f;
    public float delay = 0.0f;

    private GameObject archer;
    private Enemies archerScript;

    // Use this for initialization
    void Start () {

        archer = GameObject.FindGameObjectWithTag("Enemy");
        archerScript = archer.GetComponent<Enemies>();

    }

    // Update is called once per frame
    void Update()
    {
        if (archerScript.playerSighted == true)
        {
            FireArrows();
        }
    }

    void FireArrows()
    {
        //finds the player
        GameObject playerGO = GameObject.Find("Player");

        if (playerGO != null && timeElapse > delay) //check if the player is still alive or in game.
        {
           
            GameObject arrows = (GameObject)Instantiate(arrowGO); //sets a instantiation of the GO Arrows

            arrows.transform.position = transform.position; // sets arrow's new position

            Vector2 direction = playerGO.transform.position - arrows.transform.position; // Check for the direction of the player(where to shoot at)

                        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                      //  transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            arrows.GetComponent<Arrows>().SetDirection(direction); //sets the direction of the bullet and shoots.

            timeElapse = 0.0f;
        }

        timeElapse += Time.deltaTime;
    }

}
