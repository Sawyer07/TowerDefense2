using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int waveNumber;
    public int spawnCount;
    public float waveTimer;
    public GameObject wavePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, waveTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        spawnCount++;
        Instantiate(wavePrefab, transform.position, wavePrefab.transform.rotation);
    }
}
