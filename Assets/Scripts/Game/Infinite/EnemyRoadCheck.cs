using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoadCheck : MonoBehaviour
{
    public float MoveSpeed;
    public float RotateSpeed;
    public GameObject Monster;
    public GameObject FinalPosition;

    public bool CanMove;

    void Start(){
        CanMove = true;
    }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Tower"){
            CanMove = false;
            if(Monster.transform.position.z >= FinalPosition.transform.position.z){
                Monster.transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
            }else{
                Monster.transform.Rotate(0, -RotateSpeed * Time.deltaTime, 0);
            }
        }

        if(other.gameObject.tag == "Up Wall" || other.gameObject.tag == "Down Wall" || other.gameObject.tag == "Left Wall"){
            Monster.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(other.gameObject.tag == "Right Wall"){
            Monster.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
    private void OnTriggerExit(Collider other) {
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove){
            Monster.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
