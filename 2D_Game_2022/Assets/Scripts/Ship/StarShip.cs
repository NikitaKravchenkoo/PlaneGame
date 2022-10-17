using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : MonoBehaviour
{

    Weapon[] weapons;

    float movespeed = 3;
    int hp = 6;

    bool Moveup;
    bool Movedown;
    bool Moveleft;
    bool Moveright;

    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        weapons = transform.GetComponentsInChildren<Weapon>();
        foreach(Weapon weapon in weapons)
        {
            weapon.activeGun = true; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        Moveup = Input.GetKey(KeyCode.W);
        Movedown = Input.GetKey(KeyCode.S);
        Moveright = Input.GetKey(KeyCode.D);
        Moveleft = Input.GetKey(KeyCode.A);

        shoot = Input.GetKeyDown(KeyCode.RightCommand);
        if (shoot)
        {
            shoot = false;
            foreach(Weapon weapon in weapons)
            {
                weapon.Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        float moveAmout = movespeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if (Moveup)
        {
            move.y += moveAmout;
        }
        if (Movedown)
        {
            move.y -= moveAmout;
        }
        if (Moveright)
        {
            move.x += moveAmout;
        }
        if (Moveleft)
        {
            move.x -= moveAmout;
        }

        position += move;

        if (position.x <= -7f)
        {
            position.x = -7;
        }
        if (position.x >= 7f)
        {
            position.x = 7;
        }
        if (position.y >= 4f)
        {
            position.y = 4;
        }
        if (position.y <= -4f)
        {
            position.y = -4;
        }
        transform.position = position;
    }

    private void HealMe()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hp = hp + 2; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Charecter_bullet bullet = collision.GetComponent<Charecter_bullet>();
        if(bullet != null)
        {
            if (bullet.isEnemy)
            {
                hp = hp - 1;
                if(hp == 0)
                {
                    Destroy(gameObject);
                    Destroy(bullet.gameObject);
                }
            }
        }

        TakeDamage takeDamage = collision.GetComponent<TakeDamage>();
        if(takeDamage != null)
        {
            Destroy(gameObject);
            Destroy(takeDamage.gameObject);
        }

    }



}
