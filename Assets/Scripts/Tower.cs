using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float timer = 0f;
    public float shotsPerSecond = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; //deltaTime is time in ms since the last frame
        if (timer > shotsPerSecond)
        {
            Shoot();
            timer = 0f;
        }

        if (timer == 0)
        {
            Shoot();
        }
    }


    void Shoot()
    {
        //clone bullet and spawn it at player position using its original rotation
        GameObject obj = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        
    }

    
}
