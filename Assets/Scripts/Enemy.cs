using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int waveSize = 5;
    Waypoints Wpoints;
    public Rigidbody2D rigidBody;
    //public GameObject tower;

    int waypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Need to check if you've gone too far before you go to far, accessing Wpoints.waypoints[waypointsIndex] at all will cause an out of bounds exception
        if (waypointIndex >= Wpoints.waypoints.Length)
            return;
        
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex++;
            
        }
    }







    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Base")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.lives--;
        }
    }


    private void OnDestroy()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if(gm)
            gm.gold += 20;
        
    }
}
