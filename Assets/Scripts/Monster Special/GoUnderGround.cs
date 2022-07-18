using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoUnderGround : MonoBehaviour
{
    public float PositionX;
    public float PositionZ;
    public int GoUnderGroundTime;
    public GameObject UnderSmoke;

    public GameObject Body;
    public GameObject Right;
    public GameObject Left;
    public GameObject BloodObject;

    // Start is called before the first frame update
    void Start()
    {
        GoUnderGroundTime = Random.Range(7, 21);
        InvokeRepeating("OpenSkill", GoUnderGroundTime, GoUnderGroundTime);
    }

    void OpenSkill(){
        this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        Body.SetActive(false);
        Right.SetActive(false);
        Left.SetActive(false);
        BloodObject.SetActive(false);
        GameObject a = Instantiate(UnderSmoke, transform.position, Quaternion.identity);
        Destroy(a, 2);
        Invoke("OpenSkill2", 3);
    }

    void OpenSkill2(){
        PositionX = Random.Range(30.0f, 70.0f);
        PositionZ = Random.Range(21.0f, 8.0f);
        transform.position = new Vector3 (PositionX, 0, PositionZ);
        Body.SetActive(true);
        Right.SetActive(true);
        Left.SetActive(true);
        BloodObject.SetActive(true);
        GameObject a = Instantiate(UnderSmoke, transform.position, Quaternion.identity);
        Destroy(a, 2);
        this.gameObject.GetComponent<NavMeshAgent>().speed = 10;
    }
}
