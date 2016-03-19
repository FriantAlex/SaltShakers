using UnityEngine;
using System.Collections;

public class ArrowSocket : MonoBehaviour {
    public GameObject arrowGO;

    // Use this for initialization
    void Start () {

        

    }

    // Update is called once per frame
    void Update()
    {

        FireArrows();
    }

    void FireArrows()
    {
        //finds the player
        GameObject playerGO = GameObject.Find("Player");

        if (playerGO != null) //check if the player is still alive or in game.
        {
           
            GameObject arrows = (GameObject)Instantiate(arrowGO); //sets a instantiation of the GO Arrows

            

            arrows.transform.position = transform.position; // arrow's initial position

            Vector2 direction = playerGO.transform.position - arrows.transform.position; // Check for the direction of the player(where to shoot at)

                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            arrows.GetComponent<Arrows>().SetDirection(direction); //sets the direction of the bullet.

        }
    }
}
