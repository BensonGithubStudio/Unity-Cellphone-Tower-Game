using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAttack : MonoBehaviour
{
    public GameObject AppearPosition;
    public GameObject AttackObject;
    public float AttackTime;
    public float AttackAngle;

    // Start is called before the first frame update
    void Start()
    {
        AttackTime = Random.Range(2, 10);
        AttackAngle = Random.Range(0f, 361f);
        InvokeRepeating("OpenSkill", AttackTime, AttackTime);
    }

    void OpenSkill(){
        GameObject a = Instantiate(AttackObject, AppearPosition.transform.position, Quaternion.Euler(0, AttackAngle, 0));
        Destroy(a, 0.5f);
    }
}
