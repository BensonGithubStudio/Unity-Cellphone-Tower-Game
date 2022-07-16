using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSameMonster : MonoBehaviour
{
    public GameObject CloneMonster;
    public GameObject CloneMonsterPosition;
    public bool CanClone;

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<MonsterHpControl>().Hp < (this.gameObject.GetComponent<MonsterHpControl>().MaxHp / 4)){
            if(CanClone){
                GameObject a = Instantiate(CloneMonster, CloneMonsterPosition.transform.position, CloneMonsterPosition.transform.rotation);
                a.GetComponent<CloneSameMonster>().CanClone = false;
                CanClone = false;
            }
        }
    }
}
