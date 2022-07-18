using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusSpeed : MonoBehaviour
{
    public GameObject PlusSpeedObject;
    public int PlusSpeedTime;

    // Start is called before the first frame update
    void Start()
    {
        PlusSpeedTime = Random.Range(2, 21);
        InvokeRepeating("OpenSkill", PlusSpeedTime, PlusSpeedTime);
    }

    void OpenSkill (){
        GameObject a = Instantiate(PlusSpeedObject, transform.position, Quaternion.identity);
        Destroy(a, 2);
    }
}
