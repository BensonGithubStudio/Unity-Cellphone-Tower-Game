using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterTouchSkill : MonoBehaviour
{
    public float PlusSpeedCheckTime;
    public float PlusHeartCheckTime;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Plus Speed"){
            if(this.gameObject.GetComponent<NavMeshAgent>().speed <= 25){
                if(PlusSpeedCheckTime < 0){
                    this.gameObject.GetComponent<NavMeshAgent>().speed += 5;
                    PlusSpeedCheckTime = 1;
                }
            }
        }
        if(other.gameObject.tag == "Plus Heart"){
            if(this.gameObject.GetComponent<MonsterHpControl>().Hp < this.gameObject.GetComponent<MonsterHpControl>().MaxHp / 2){
                if(PlusHeartCheckTime  < 0){
                    this.gameObject.GetComponent<MonsterHpControl>().Hp += (this.gameObject.GetComponent<MonsterHpControl>().MaxHp / 2);
                    PlusHeartCheckTime = 1;
                }
            }
        }
    }

    void Update(){
        PlusSpeedCheckTime -= Time.deltaTime;
        PlusHeartCheckTime -= Time.deltaTime;
    }
}
