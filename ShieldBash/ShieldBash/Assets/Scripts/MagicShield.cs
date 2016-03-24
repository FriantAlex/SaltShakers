using UnityEngine;
using System.Collections;

public class MagicShield : MonoBehaviour {
    public float rotSpeed;
    public Vector3 target;

    private Transform transform;
    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        if (Input.GetKey(KeyCode.A))
            transform.RotateAround(target, Vector3.forward, rotSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.RotateAround(target, Vector3.forward, -rotSpeed * Time.deltaTime);



    }
}
