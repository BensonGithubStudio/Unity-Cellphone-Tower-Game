using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHpControl : MonoBehaviour
{
    public GameObject GameControlGameObject;

    public float Hp;
    public float MaxHp;
    public GameObject BloodBar;
    public int EarnMoney;

    // Start is called before the first frame update
    void Start()
    {
        GameControlGameObject = GameObject.Find("Game Control");

        if(GameControlGameObject.GetComponent<GameButton>().ThisScene != "Infinite Level"){
            Hp = MaxHp;
        }
        if(!PlayerPrefs.HasKey("InfiniteScene")){
            Hp = MaxHp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BloodBar.transform.localScale = new Vector3 (Hp / MaxHp, 1, 1);

        if(Hp <= 0){
            GameControlGameObject.GetComponent<MoneyControl>().Money += EarnMoney;
            Destroy(this.gameObject);
        }
    }
}
