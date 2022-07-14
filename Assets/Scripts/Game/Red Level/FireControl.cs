using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    [Header("紅火管理")]
    public GameObject RedFire;
    public float RedFirePositionX;
    public float RedFirePositionY;
    public float RedFirePositionZ;

    [Header("藍火管理")]
    public GameObject BlueFire;
    public float BlueFirePositionX;
    public float BlueFirePositionY;
    public float BlueFirePositionZ;

    // Start is called before the first frame update
    void Start()
    {
        if(RedFire != null){
            InvokeRepeating("AddRedFire", 0, 2f);
        }
        if(BlueFire != null){
            InvokeRepeating("AddBlueFire", 1, 2f);
        }
    }

    void AddRedFire(){
        RedFirePositionX = Random.Range(27.0f, 72.0f);
        RedFirePositionY = 0.25f;
        RedFirePositionZ = Random.Range(26.0f, 2.5f);

        GameObject a = Instantiate(RedFire, new Vector3(RedFirePositionX, RedFirePositionY, RedFirePositionZ), Quaternion.identity);
        Destroy(a, 2);
    }
    void AddBlueFire(){
        BlueFirePositionX = Random.Range(27.0f, 72.0f);
        BlueFirePositionY = 0.25f;
        BlueFirePositionZ = Random.Range(26.0f, 2.5f);

        GameObject a = Instantiate(BlueFire, new Vector3(BlueFirePositionX, BlueFirePositionY, BlueFirePositionZ), Quaternion.identity);
        Destroy(a, 2);
    }
}
