using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTowerBullet : MonoBehaviour
{
    public float BulletMoveSpeed;
    public float BulletStrong;
    public float DelayTime;
    public bool CanMove;
    public GameObject BombParticle;

    void start(){
        Destroy(this.gameObject, 2);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<MonsterHpControl>().Hp -= BulletStrong;
            Invoke("Setup", 0.05f);
        }
    }

    void Setup(){
        CanMove = false;
        GameObject a = Instantiate(BombParticle, transform.position, transform.rotation);
        Destroy(a, 0.5f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove){
            transform.Translate(0, 0, BulletMoveSpeed * Time.deltaTime);
        }
    }
}
