using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoadCheck : MonoBehaviour
{
    [Header("AI管理")]
    public NavMeshAgent MonsterAgent;
    public GameObject AIFinalPosition;

    void Update(){
        MonsterAgent.SetDestination(AIFinalPosition.transform.position);
    }
}
