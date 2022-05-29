using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject[] TrapToSpawn;
    public float Delay;
    public float ChanceToSpawn = 0;

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

       
        if (timeFromSpawn >= temporaryDelay)
        {
            int chance = Random.Range(0,11);
            if(ChanceToSpawn >= chance)
            {
                Instantiate(TrapToSpawn[random.Next(TrapToSpawn.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                
            }
            timeFromSpawn = 0;
        }

        timeFromSpawn += Time.deltaTime;
    }
}
