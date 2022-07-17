using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerTouchSkill : MonoBehaviour
{
    [Header("冰涷管理")]
    public float TowerFreezonTime;
    public GameObject FreezonObject;
    [Header("向下掃射管理")]
    public GameObject Smoke;
    public GameObject ThisTower;
    public GameObject TowerDestroyWarm;
    public GameObject TowerDestroyWarmText;

    [Header("暈眩管理")]
    public float TowerDizzyTime;
    public GameObject TowerDizzyObject;
    public float TowerShootSpeed;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Freezon"){
            TowerFreezonTime = 2f;
        }
        if(other.gameObject.tag == "Down Attack"){
            Smoke.SetActive(false);
            Smoke.SetActive(true);
            Invoke("DestroyThisTower", 1);
        }
        if(other.gameObject.tag == "Dizzy"){
            TowerDizzyTime = 2f;
        }
    }

    void DestroyThisTower(){
        TowerDestroyWarm.SetActive(false);
        TowerDestroyWarm.SetActive(true);
        if(ThisTower.GetComponentInChildren<TowerShoot>().TowerLevel <= 10){
            TowerDestroyWarmText.GetComponent<Text>().text = "我方砲塔被擊毀";
            Destroy(ThisTower);
        }else if(ThisTower.GetComponentInChildren<TowerShoot>().TowerLevel > 10){
            TowerDestroyWarmText.GetComponent<Text>().text = "我方砲塔被降級";
            ThisTower.GetComponentInChildren<TowerShoot>().TowerLevel -= 10;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TowerDestroyWarm = GameObject.Find("Tower Destroy Warm");
        TowerDestroyWarmText = GameObject.Find("Tower Destroy Warm Text");
        TowerShootSpeed = this.gameObject.GetComponent<TowerShoot>().ShootSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        TowerFreezonTime -= Time.deltaTime;
        TowerDizzyTime -= Time.deltaTime;

        //砲塔被冰凍
        if(TowerFreezonTime >= 0){
            this.gameObject.GetComponent<TowerShoot>().IsRun = false;
            FreezonObject.SetActive(true);
        }else{
            this.gameObject.GetComponent<TowerShoot>().IsRun = true;
            FreezonObject.SetActive(false);
        }

        //砲塔被暈眩
        if(TowerDizzyTime >= 0){
            this.gameObject.GetComponent<TowerShoot>().ShootSpeed = TowerShootSpeed * 2;
            TowerDizzyObject.SetActive(true);
        }else{
            this.gameObject.GetComponent<TowerShoot>().ShootSpeed = TowerShootSpeed;
            TowerDizzyObject.SetActive(false);
        }
    }
}
