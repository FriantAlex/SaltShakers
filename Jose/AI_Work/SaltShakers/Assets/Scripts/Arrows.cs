using UnityEngine;
using System.Collections;

public class Arrows : MonoBehaviour {

    public float speed;
    private Vector2 _direction;
    public bool isReady;

    void Awake()
    {
        speed = 10f;
        isReady = false;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isReady)
        {
            Vector2 position = transform.position;

            position += _direction * speed * Time.deltaTime;

            transform.position = position;

            //bottom left point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            //top right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //destroy bullet if outside screen.
            if ((transform.position.x < min.x) || (transform.position.y > min.y) || (transform.position.x < max.x) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }



    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;

        isReady = true;
    }
}
