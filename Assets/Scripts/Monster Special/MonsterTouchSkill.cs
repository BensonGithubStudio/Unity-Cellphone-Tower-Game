using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTouchSkill : MonoBehaviour
{
    public float PlusSpeedCheckTime;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Plus Speed"){
            if(this.gameObject.GetComponent<MonsterMove>().speed <= 25){
                if(PlusSpeedCheckTime < 0){
                    this.gameObject.GetComponent<MonsterMove>().speed  += 5;
                    PlusSpeedCheckTime = 1;
                }
            }
        }
    }

    void Update(){
        PlusSpeedCheckTime -= Time.deltaTime;
    }
}
