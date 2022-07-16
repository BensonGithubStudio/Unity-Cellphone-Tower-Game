using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTouchSkill : MonoBehaviour
{
    public float TowerFreezonTime;
    public GameObject FreezonObject;

    void OnTriggerEnter(Collider other) {
        print("1111");
        if(other.gameObject.tag == "Freezon"){
            print("2222");
            TowerFreezonTime = 2f;
        }
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
