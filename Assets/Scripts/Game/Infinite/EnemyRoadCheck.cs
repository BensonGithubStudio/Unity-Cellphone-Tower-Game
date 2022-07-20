using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoadCheck : MonoBehaviour
{
    [Header("AI管理")]
    public NavMeshAgent MonsterAgent;
    public GameObject AIFinalPosition;
    public float RoadBlockTime;
    public GameObject GameControlGameObject;

    void Start(){
        GameControlGameObject = GameObject.Find("Game Control");
    }

    void Update(){
        MonsterAgent.SetDestination(AIFinalPosition.transform.position);
    }
}
