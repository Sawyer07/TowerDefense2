using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int enemyOneHp = 4;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Projectile")
        {
            Projectile projectileScript = collision.GetComponent<Projectile>();
            enemyOneHp -= projectileScript.damage;

            Destroy(collision.gameObject); //destroy bullet
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyOneHp <= 0)
        {
             Destroy(gameObject);

        }
    }
}