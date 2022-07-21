using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyControl : MonoBehaviour
{
    public Text NowHaveMoneyText;
    public int Money;
    public int SaveMoney;
    public bool CanSaveMoney;

    // Start is called before the first frame update
    void Start()
    {
        CanSaveMoney = true;
    }

    // Update is called once per frame
    void Update()
    {
        NowHaveMoneyText.text = Money + "$";

        if(!this.gameObject.GetComponent<GameButton>().MoneyInfinite){
            if(CanSaveMoney == false){
                Money = SaveMoney;
                CanSaveMoney = true;
            }
        }

        if(this.gameObject.GetComponent<GameButton>().MoneyInfinite){
            if(CanSaveMoney){
                SaveMoney = Money;
                CanSaveMoney = false;
            }
            Money = 2147483647;
        }
    }
}
