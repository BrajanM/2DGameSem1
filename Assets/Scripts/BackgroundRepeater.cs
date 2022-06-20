using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{

    public float SpawnPositionX;
    public float EndPositionX;
    
   

    private void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.x <= EndPositionX)
        {
            transform.position = new Vector3(SpawnPositionX,transform.position.y,transform.position.z);
        }  

    }
}
