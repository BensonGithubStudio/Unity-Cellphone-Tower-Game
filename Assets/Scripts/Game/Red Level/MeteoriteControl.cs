using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteControl : MonoBehaviour
{
    public GameObject Stone;
    public float StonePositionX;
    public float StonePositionY;
    public float StonePositionZ;

    // Start is called before the first frame update
    void Start()
    {
        if(Stone != null){
            InvokeRepeating("AddStone", 5f, 5f);
        }
    }

    void AddStone(){
        StonePositionX = Random.Range(90.0f, 130.0f);
        StonePositionY = 62f;
        StonePositionZ = Random.Range(26.0f, 2.5f);

        GameObject a = Instantiate(Stone, new Vector3(StonePositionX, StonePositionY, StonePositionZ), Quaternion.identity);
        Destroy(a, 2);
    }
}
