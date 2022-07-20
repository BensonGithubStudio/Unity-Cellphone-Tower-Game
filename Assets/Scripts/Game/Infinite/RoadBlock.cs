using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoadBlock : MonoBehaviour
{
    [Header("AI管理")]
    public NavMeshAgent RoadBlockAgent;
    public GameObject AIFinalPosition;
    public float RoadBlockTime;
    public GameObject GameControlGameObject;

    void Update(){
        RoadBlockAgent.SetDestination(AIFinalPosition.transform.position);

        print(RoadBlockAgent.pathPending);
        
        if(RoadBlockAgent.pathPending){
            RoadBlockTime += Time.deltaTime;
        }else{
            RoadBlockTime = 0;
        }
        if(RoadBlockTime >= 0.5f){
            Time.timeScale = 0;
            GameControlGameObject.GetComponent<InfiniteLevelControl>().RoadBlockWarm.SetActive(true);
        }else{
            GameControlGameObject.GetComponent<InfiniteLevelControl>().RoadBlockWarm.SetActive(false);
        }
    }
}
