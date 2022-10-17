using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter_bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public float speed = 20;

    public Vector2 velocity;

    public bool isEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;   
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;

        position += velocity * Time.fixedDeltaTime;

        transform.position = position;
    }
}
