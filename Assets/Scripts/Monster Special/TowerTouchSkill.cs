using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTouchSkill : MonoBehaviour
{
    [Header("冰涷管理")]
    public float TowerFreezonTime;
    public GameObject FreezonObject;
    [Header("向下掃射管理")]
    public GameObject Smoke;
    public GameObject ThisTower;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Freezon"){
            TowerFreezonTime = 2f;
        }
        if(other.gameObject.tag == "Down Attack"){
            Smoke.SetActive(true);
            Invoke("DestroyThisTower", 1);
        }
    }

    void DestroyThisTower(){
        Destroy(ThisTower);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TowerFreezonTime -= Time.deltaTime;

        if(TowerFreezonTime >= 0){
            this.gameObject.GetComponent<TowerShoot>().IsRun = false;
            FreezonObject.SetActive(true);
        }else{
            this.gameObject.GetComponent<TowerShoot>().IsRun = true;
            FreezonObject.SetActive(false);
        }
    }
}
