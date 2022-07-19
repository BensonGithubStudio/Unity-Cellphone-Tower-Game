using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfiniteSceneSave : MonoBehaviour
{
    public GameObject TowerAll;
    public bool SaveGame;
    public bool HaveSaveGame;

    [Header("遊戲物件資料")]
    public Image BombColdImage;
    public Image FreezeColdImage;
    public GameObject[] TowerPosition;

    [Header("儲存參數")]
    public int TowerPositionNumber;
    public int TowerPositionLevelNumber;

    // Start is called before the first frame update
    void Start()
    {
        SaveGame = false;
        HaveSaveGame = false;
        TowerPositionNumber = 1;
        TowerPositionLevelNumber = 1;

        if(PlayerPrefs.GetInt("InfiniteScene") == 1){
            Time.timeScale = 0;
            this.gameObject.GetComponent<MoneyControl>().Money = PlayerPrefs.GetInt("InfiniteMoney");
            this.gameObject.GetComponent<HeartControl>().Heart = PlayerPrefs.GetInt("InfiniteHeart");
            this.gameObject.GetComponent<InfiniteLevelControl>().NowWave = PlayerPrefs.GetInt("InfiniteWave");
            this.gameObject.GetComponent<InfiniteLevelControl>().EnemyBlood = PlayerPrefs.GetInt("InfiniteBlood");
            this.gameObject.GetComponent<InfiniteLevelControl>().GetMoney = PlayerPrefs.GetInt("InfiniteGetMoney");
            this.gameObject.GetComponent<InfiniteLevelControl>().EnemyAppearTime = PlayerPrefs.GetInt("EnemyAppearTime");
            BombColdImage.fillAmount = PlayerPrefs.GetFloat("BombColdImage");
            FreezeColdImage.fillAmount = PlayerPrefs.GetFloat("FreezeColdImage");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveGame == true){
            if(HaveSaveGame == false){
                SystemSaveGame();
                HaveSaveGame = true;
            }
        }
    }

    void SystemSaveGame(){
        PlayerPrefs.SetInt("InfiniteScene", 1);
        TowerAll.SetActive(true);

        //遊戲參數儲存
        int money = this.gameObject.GetComponent<MoneyControl>().Money;
        PlayerPrefs.SetInt("InfiniteMoney", money);
        int heart = this.gameObject.GetComponent<HeartControl>().Heart;
        PlayerPrefs.SetInt("InfiniteHeart", heart);
        int wave = this.gameObject.GetComponent<InfiniteLevelControl>().NowWave;
        PlayerPrefs.SetInt("InfiniteWave", wave);
        int blood = this.gameObject.GetComponent<InfiniteLevelControl>().EnemyBlood;
        PlayerPrefs.SetInt("InfiniteBlood", blood);
        int getMoney = this.gameObject.GetComponent<InfiniteLevelControl>().GetMoney;
        PlayerPrefs.SetInt("InfiniteGetMoney", getMoney);
        int enemyAppearTime = this.gameObject.GetComponent<InfiniteLevelControl>().EnemyAppearTime;
        PlayerPrefs.SetInt("EnemyAppearTime", enemyAppearTime);
        float bombColdImage = BombColdImage.fillAmount;
        PlayerPrefs.SetFloat("BombColdImage", bombColdImage);
        float freezeColdImage = FreezeColdImage.fillAmount;
        PlayerPrefs.SetFloat("FreezeColdImage", freezeColdImage);

        //砲塔位置儲存
        foreach(GameObject towerPosition in TowerPosition){
            GameObject Tower = null;
            string TowerKindNumber;
            int NowTower = 0;
            string TowerLevelNumber;
            int NowTowerLevel = 0;

            TowerKindNumber = "TowerPosition" + TowerPositionNumber;
            TowerLevelNumber = "TowerLevel" + TowerPositionLevelNumber;

            if(towerPosition.GetComponent<BuildTower>().CloneArmy != null){
                Tower = towerPosition.GetComponent<BuildTower>().CloneArmy;
            }
            if(Tower == null){
                NowTower = 0;
            }else if(Tower.GetComponentInChildren<TowerShoot>().TheTower == "Single"){
                NowTower = 1;
            }else if(Tower.GetComponentInChildren<TowerShoot>().TheTower == "Quick"){
                NowTower = 2;
            }else if(Tower.GetComponentInChildren<TowerShoot>().TheTower == "Laser"){
                NowTower = 3;
            }else if(Tower.GetComponentInChildren<TowerShoot>().TheTower == "Bomb"){
                NowTower = 4;
            }
            if(Tower != null){
                NowTowerLevel = Tower.GetComponentInChildren<TowerShoot>().TowerLevel;
                print(Tower.GetComponentInChildren<TowerShoot>().TowerLevel);
            }

            PlayerPrefs.SetInt(TowerKindNumber, NowTower);
            PlayerPrefs.SetInt(TowerLevelNumber, NowTowerLevel);

            TowerPositionNumber += 1;
            TowerPositionLevelNumber += 1;
        }

        SceneManager.LoadScene("ChooseLevel");
    }
}
