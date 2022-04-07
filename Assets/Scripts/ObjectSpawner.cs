using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject ObjectToSpawn;
    public float Delay;
    public float[] SpawnPoints;

    float timeFromSpawn;
    System.Random random = new System.Random();


    void Start()
    {
        timeFromSpawn = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeFromSpawn>= Delay)
        {
            Instantiate(ObjectToSpawn, new Vector3(transform.position.x, SpawnPoints[random.Next(0, SpawnPoints.Length)], transform.position.z), ObjectToSpawn.transform.rotation);
            timeFromSpawn = 0;
        }

        timeFromSpawn += Time.deltaTime;
    }
}
