using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteMove : MonoBehaviour
{
    public float MoveSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-MoveSpeed * Time.deltaTime, -MoveSpeed * Time.deltaTime, 0);
    }
}
