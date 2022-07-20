using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusHeart : MonoBehaviour
{
    public GameObject PlusHeartObject;
    public float PlusHeartTime;

    // Start is called before the first frame update
    void Start()
    {
        PlusHeartTime = Random.Range(2, 21);
        Invoke("OpenSkill", PlusHeartTime);
    }

    void OpenSkill(){
        GameObject a = Instantiate(PlusHeartObject, transform.position, Quaternion.identity);
        Destroy(a, 2);
        PlusHeartTime = Random.Range(2, 21);
        Invoke("OpenSkill", PlusHeartTime);
    }
}
