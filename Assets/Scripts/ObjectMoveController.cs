using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveController : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        float temporarySpeed = Speed * GameHandler.GameSpeed;
        transform.position -= new Vector3(temporarySpeed * Time.deltaTime, 0, 0);
    }
}
