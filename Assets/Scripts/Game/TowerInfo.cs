using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public GameObject TowerAll;
    public GameObject GameControlGameObject;

    public GameObject RangeImage;
    public GameObject TowerInfoUI;

    public bool IsAppearInfo;

    public int TowerSellPrice;

    void Start(){
        GameControlGameObject = GameObject.Find("Game Control");
    }

    // Start is called before the first frame update
    public void OnClickTowerInfo(){
        if(IsAppearInfo){
            RangeImage.SetActive(false);
            TowerInfoUI.SetActive(false);
            IsAppearInfo = false;
        }else{
            RangeImage.SetActive(true);
            TowerInfoUI.SetActive(true);
            IsAppearInfo = true;
        }
    }

    public void OnClickSellTower(){
        GameControlGameObject.GetComponent<MoneyControl>().Money += TowerSellPrice;
        Destroy(TowerAll);
    }
}
