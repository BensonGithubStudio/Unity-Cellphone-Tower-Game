using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandControl : MonoBehaviour
{
    public GameObject Sand;
    public float SandPositionX;
    public float SandPositionY;
    public float SandPositionZ;

    // Start is called before the first frame update
    void Start()
    {
        if(Sand != null){
            InvokeRepeating("AddSand", 0, 2f);
        }
    }

    void AddSand(){
        SandPositionX = Random.Range(27.0f, 72.0f);
        SandPositionY = 0.25f;
        SandPositionZ = Random.Range(26.0f, 2.5f);

        GameObject a = Instantiate(Sand, new Vector3(SandPositionX, SandPositionY, SandPositionZ), Quaternion.identity);
        Destroy(a, 2);
    }
}
