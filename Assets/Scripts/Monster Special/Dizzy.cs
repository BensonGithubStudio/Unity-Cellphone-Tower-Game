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
        DizzyTime = Random.Range(2, 21);
        Invoke("OpenSkil", DizzyTime);
    }

    void OpenSkil(){
        GameObject a = Instantiate(DizzyObject, transform.position, Quaternion.identity);
        Destroy(a, 2);
        DizzyTime = Random.Range(2, 21);
        Invoke("OpenSkil", DizzyTime);
    }
}
