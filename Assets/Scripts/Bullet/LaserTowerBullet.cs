using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerBullet : MonoBehaviour
{
    public float BulletStrong;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<MonsterHpControl>().Hp -= BulletStrong;
        }
    }
}
