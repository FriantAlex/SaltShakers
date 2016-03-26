using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class BouncingLaser : MonoBehaviour
{

	public int dist; //max travel distance
	public LineRenderer line; // the laser
	public string reflectTag;  // what the laser can bounce off of
	public string targetTag;
	public int limit; // how many times it can bounce
	public bool isHit;

	private int verti =  1;  //laser segment handler leave as is
	private bool isActive;
	private Vector3 currentRot; //current rotation
	private Vector3 currentPos; //current position

    public bool ifActive = false;

	void Update(){

        //	line.enabled = Input.GetKey (KeyCode.Space);

        //if (Input.GetKey (KeyCode.Space) || Input.GetKeyUp (KeyCode.Space))
        if (ifActive == true)
        {
            DrawLaser();
        }
	}

	void DrawLaser(){

		int timesReflected = 1; //how many times the laser has bounced
		int vertexCounter = 1; //how many segments there are
		bool loopActive = true;
		Vector3 laserDir = -transform.up; // direction of the next laser
		Vector3 lastLaserPos = this.transform.position; // orgin of the next laser
		RaycastHit hit;

		line.SetVertexCount (1);
		line.SetPosition (0, transform.position);


		while (loopActive) {
			 

			if (Physics.Raycast(lastLaserPos, laserDir, out hit, dist) && hit.transform.gameObject.tag == reflectTag) {

				Debug.Log ("BoopBoop");
				timesReflected++;
				vertexCounter += 3;
				line.SetVertexCount (vertexCounter);
				line.SetPosition (vertexCounter-3, Vector3.MoveTowards(hit.point, lastLaserPos, 0.01f));
				line.SetPosition(vertexCounter-2, hit.point);
				line.SetPosition(vertexCounter-1, hit.point);
				lastLaserPos = hit.point;
				laserDir = Vector3.Reflect(laserDir, hit.normal);

			} else {
				Debug.Log ("No Boop");
				timesReflected++;
				vertexCounter++;
				line.SetVertexCount (vertexCounter);
				line.SetPosition (vertexCounter - 1, lastLaserPos + (laserDir.normalized * dist));

				loopActive = false;
			}

			if (Physics.Raycast (lastLaserPos, laserDir, out hit, dist) && hit.transform.gameObject.tag == targetTag)
            {
                isHit = true;

                string hitObject;
                hitObject = hit.transform.gameObject.transform.parent.name.ToString();
                Debug.Log(hitObject);

                hit.transform.gameObject.transform.parent.gameObject.GetComponent<Enemies>().enemyLazerDamage -= .1f;
                

            }

            if (Physics.Raycast(lastLaserPos, laserDir, out hit, dist) && hit.transform.gameObject.tag == "Player3D")
            {
                //if player hit
                isHit = true;

                StartCoroutine(Damage());

            }
            

            }


                if (timesReflected > limit)
				loopActive = false;
		}
        IEnumerator Damage()
    {
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().health -= .1f;

        yield return new WaitForSeconds(10f);


    }
	}

