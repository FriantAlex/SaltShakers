using UnityEngine;
using System.Collections;

public class Arrows : MonoBehaviour {

    public float speed;
    private Vector2 _direction;
    public bool isReady;

    void Awake()
    {
        speed = 10f; //speed of arrow toward player
        isReady = false;
    }


    // Use this for initialization
    void Start()
    {

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
}
