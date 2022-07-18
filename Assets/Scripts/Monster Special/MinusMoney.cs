using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusMoney : MonoBehaviour
{
    public GameObject MinusMoneyObject;
    public int MinusMoneyTime;

    // Start is called before the first frame update
    void Start()
    {
        MinusMoneyTime = Random.Range(2, 21);
        InvokeRepeating("OpenSkill", MinusMoneyTime, MinusMoneyTime);
    }

    void OpenSkill (){
        GameObject a = Instantiate(MinusMoneyObject, transform.position, Quaternion.identity);
        Destroy(a, 2);
    }
}
