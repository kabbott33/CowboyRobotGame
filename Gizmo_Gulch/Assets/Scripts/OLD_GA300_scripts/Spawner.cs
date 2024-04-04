using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spider;
    public GameObject spawnPoint;
    public float Interval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnerMethod",0f, Interval);
    }

    private void SpawnerMethod()
    {
        Instantiate(spider, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
