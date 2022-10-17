using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Charecter_bullet bullet;
    Vector2 direction;

    public bool autoShoot = false;
    public float shootInterval = 0.5f;
    public float shootDelay = 0f;
    float shootTimer = 0f;
    float delayTimer = 0f;

    public bool activeGun = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activeGun)
        {
            return;
        }

        direction = (transform.localRotation * Vector2.right).normalized;

        if (autoShoot)
        {
            if (delayTimer >= shootDelay)
            {
                if(shootTimer >= shootInterval)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Charecter_bullet goBullet = go.GetComponent<Charecter_bullet>();
        goBullet.direction = direction;
    }
}
