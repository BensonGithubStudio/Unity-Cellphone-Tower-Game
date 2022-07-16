using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUnderGround : MonoBehaviour
{
    public float PositionX;
    public float PositionZ;
    public int GoUnderGroundTime;
    public bool CanUnder;
    public GameObject UnderSmoke;

    // Start is called before the first frame update
    void Start()
    {
        CanUnder = false;
        GoUnderGroundTime = Random.Range(10, 20);
        InvokeRepeating("OpenSkill", GoUnderGroundTime, GoUnderGroundTime);
    }

    void OpenSkill(){
        CanUnder = true;
        GameObject a = Instantiate(UnderSmoke, transform.position, Quaternion.identity);
        Destroy(a, 2);
        Invoke("OpenSkill2", 3);
    }

    void OpenSkill2(){
        CanUnder = false;
        PositionX = Random.Range(30.0f, 70.0f);
        PositionZ = Random.Range(21.0f, 8.0f);
        transform.position = new Vector3 (PositionX, 0, PositionZ);
        GameObject a = Instantiate(UnderSmoke, transform.position, Quaternion.identity);
        this.gameObject.GetComponentInChildren<EnemyRoadCheck>().CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanUnder){
            transform.Translate(0, -1 * Time.deltaTime, 0);
            this.gameObject.GetComponentInChildren<EnemyRoadCheck>().CanMove = false;
        }
    }
}
