using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dizzy : MonoBehaviour
{
    public GameObject DizzyObject;
    public float DizzyTime;

    // Start is called before the first frame update
    void Start()
    {
        DizzyTime = Random.Range(10, 20);
        InvokeRepeating("OpenSkil", DizzyTime, DizzyTime);
    }

    void OpenSkil(){
        GameObject a = Instantiate(DizzyObject, transform.position, Quaternion.identity);
        Destroy(a, 2);
    }
}
