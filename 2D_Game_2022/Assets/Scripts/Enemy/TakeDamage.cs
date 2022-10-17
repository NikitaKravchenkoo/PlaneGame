using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public GameObject explotion;
    bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 9f && !isActive)
        {
            isActive = true;
            Weapon[] weapons = transform.GetComponentsInChildren<Weapon>();
            foreach (Weapon weapon in weapons)
            {
                weapon.activeGun = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
        {
            return;
        }
        Charecter_bullet bullet = collision.GetComponent<Charecter_bullet>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                DestroyShip();
                Destroy(bullet.gameObject);
            }

        }
    }
    void DestroyShip()
    {
        Instantiate(explotion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
