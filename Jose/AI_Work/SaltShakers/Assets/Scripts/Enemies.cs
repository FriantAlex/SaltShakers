using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

    public Transform target;
    private Transform myTransform;
    private GameObject playerGO;
    public bool playerSighted = false;


    void Awake()
    {
        myTransform = transform;
        
    }

    // Use this for initialization
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");

        target = playerGO.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerSighted == true)
        {
            Debug.DrawLine(target.position, myTransform.position, Color.cyan);

            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

  
}
