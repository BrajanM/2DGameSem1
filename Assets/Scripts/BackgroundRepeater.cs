using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{

    public float TargetSpeed;
    Vector2 offset;
    float currentSpeed;
    float maxSpeed;
   

    private void Start()
    {
        currentSpeed = TargetSpeed;
        
    }
    void Update()
    {
        maxSpeed = TargetSpeed * GameHandler.GameSpeed;

        if (currentSpeed < maxSpeed)
        {
            currentSpeed += (maxSpeed - currentSpeed) * 0.001f;
        }
        if (currentSpeed > maxSpeed)
        {
            //currentSpeed = (currentSpeed - maxSpeed) * 0.001f;
            currentSpeed += (maxSpeed - currentSpeed) * 0.001f;

        }

        offset = new Vector2(currentSpeed * Time.time, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;

    }
}
