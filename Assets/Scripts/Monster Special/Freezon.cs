using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezon : MonoBehaviour
{
    public GameObject FreezonObject;
    public int FreezonTime;

    // Start is called before the first frame update
    void Start()
    {
        FreezonTime = Random.Range(2, 21);
        Invoke("OpenSkill", FreezonTime);
    }

    void OpenSkill (){
        GameObject a = Instantiate(FreezonObject, transform.position, Quaternion.identity);
        Destroy(a, 2);
        FreezonTime = Random.Range(2, 21);
        Invoke("OpenSkill", FreezonTime);
    }
}
