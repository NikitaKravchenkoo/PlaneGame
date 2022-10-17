using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float movespeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= movespeed * Time.fixedDeltaTime;

        if (pos.x < 7)
        {
            Destroy(gameObject, 60);
        }
        else
        {
            transform.position = pos;
        }

    }
}
