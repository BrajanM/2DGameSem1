using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject[] ObjectToSpawn;
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
        float temporaryDelay = Delay / GameHandler.GameSpeed;

        if(timeFromSpawn>= temporaryDelay)
        {
            int objectToSpawnIndex = random.Next(ObjectToSpawn.Length);
            int spawnPointsIndex = random.Next(0, SpawnPoints.Length);

            Instantiate(ObjectToSpawn[objectToSpawnIndex], new Vector3(transform.position.x, SpawnPoints[spawnPointsIndex], transform.position.z), transform.rotation);
            timeFromSpawn = 0;
        }

        timeFromSpawn += Time.deltaTime;
    }
}
