using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTowerBullet : MonoBehaviour
{
    public float BulletMoveSpeed;
    public float BulletStrong;
    public bool IsExist;

    void start(){
        Destroy(this.gameObject, 2);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            if(IsExist){
                other.gameObject.GetComponent<MonsterHpControl>().Hp -= BulletStrong;
                IsExist = false;
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, BulletMoveSpeed * Time.deltaTime);
    }
}
