 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float delay = 3;
    private float nextSpawnTime;
    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
        
    }
    private void Spawn()
    {
        nextSpawnTime = Time.time + delay;
        Instantiate(prefab, transform.position, transform.rotation);
    }
    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
