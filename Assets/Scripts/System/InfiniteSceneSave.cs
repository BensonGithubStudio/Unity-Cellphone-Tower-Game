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
    public GameObject[] CloneMonster;
    public GameObject[] TowerPosition;
    public GameObject [] GameMonster;

    [Header("儲存參數")]
    public int TowerPositionNumber;
    public int TowerPositionLevelNumber;
    public int MonsterNumber;

    // Start is called before the first frame update
    void Start()
    {
        SaveGame = false;
        HaveSaveGame = false;
        TowerPositionNumber = 1;
        TowerPositionLevelNumber = 1;
        MonsterNumber = 1;

        if(PlayerPrefs.GetInt("InfiniteScene") == 1){
            Time.timeScale = 0;

            //遊戲參數恢復
            this.gameObject.GetComponent<MoneyControl>().Money = PlayerPrefs.GetInt("InfiniteMoney");
            this.gameObject.GetComponent<HeartControl>().Heart = PlayerPrefs.GetInt("InfiniteHeart");
            this.gameObject.GetComponent<InfiniteLevelControl>().NowWave = PlayerPrefs.GetInt("InfiniteWave");
            this.gameObject.GetComponent<InfiniteLevelControl>().EnemyBlood = PlayerPrefs.GetInt("InfiniteBlood");
            this.gameObject.GetComponent<InfiniteLevelControl>().GetMoney = PlayerPrefs.GetInt("InfiniteGetMoney");
            this.gameObject.GetComponent<InfiniteLevelControl>().EnemyAppearTime = PlayerPrefs.GetInt("EnemyAppearTime");
            BombColdImage.fillAmount = PlayerPrefs.GetFloat("BombColdImage");
            FreezeColdImage.fillAmount = PlayerPrefs.GetFloat("FreezeColdImage");

            //製作敵人
            for (int i = 1; i <= PlayerPrefs.GetInt("MonsterCount"); i++)
            {
                string monsterAll = "MonsterAll" + i;
                string monsterPositionX = "MonsterPositionX" + i;
                string monsterPositionY = "MonsterPositionY" + i;
                string monsterPositionZ = "MonsterPositionZ" + i;
                string monsterRotationX = "MonsterRotationX" + i;
                string monsterRotationY = "MonsterRotationY" + i;
                string monsterRotationZ = "MonsterRotationZ" + i;
                string monsterNowBlood = "MonsterNowBlood" + i;
                string monsterMaxBlood = "MonsterMaxBlood" + i;

                GameObject mon = Instantiate(CloneMonster[PlayerPrefs.GetInt(monsterAll) - 1], new Vector3(PlayerPrefs.GetFloat(monsterPositionX), PlayerPrefs.GetFloat(monsterPositionY), PlayerPrefs.GetFloat(monsterPositionZ)), Quaternion.Euler(PlayerPrefs.GetFloat(monsterRotationX), PlayerPrefs.GetFloat(monsterRotationY), PlayerPrefs.GetFloat(monsterRotationZ)));
                mon.GetComponent<MonsterHpControl>().Hp = PlayerPrefs.GetFloat(monsterNowBlood);
                mon.GetComponent<MonsterHpControl>().MaxHp = PlayerPrefs.GetFloat(monsterMaxBlood);
            }
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

        //砲塔種類、位置及等級儲存
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
            }

            PlayerPrefs.SetInt(TowerKindNumber, NowTower);
            PlayerPrefs.SetInt(TowerLevelNumber, NowTowerLevel);

            TowerPositionNumber += 1;
            TowerPositionLevelNumber += 1;
        }

        //敵人種類、位置及血量儲存
        GameMonster = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject gameMonster in GameMonster){
            if(gameMonster.GetComponent<MonsterIsParent>() != null){
                int monsterKind = 0;
                string monsterAll = "MonsterAll" + MonsterNumber;
                string monsterPositionX = "MonsterPositionX" + MonsterNumber;
                string monsterPositionY = "MonsterPositionY" + MonsterNumber;
                string monsterPositionZ = "MonsterPositionZ" + MonsterNumber;
                string monsterRotationX = "MonsterRotationX" + MonsterNumber;
                string monsterRotationY = "MonsterRotationY" + MonsterNumber;
                string monsterRotationZ = "MonsterRotationZ" + MonsterNumber;
                string monsterNowBlood = "MonsterNowBlood" + MonsterNumber;
                string monsterMaxBlood = "MonsterMaxBlood" + MonsterNumber;

                if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon1"){
                    monsterKind = 1;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon2"){
                    monsterKind = 2;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon3"){
                    monsterKind = 3;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon4"){
                    monsterKind = 4;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon5"){
                    monsterKind = 5;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon6"){
                    monsterKind = 6;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon7"){
                    monsterKind = 7;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon8"){
                    monsterKind = 8;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon9"){
                    monsterKind = 9;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon10"){
                    monsterKind = 10;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon11"){
                    monsterKind = 11;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon12"){
                    monsterKind = 12;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon13"){
                    monsterKind = 13;
                }else if(gameMonster.GetComponent<MonsterIsParent>().ThisMonsterName == "mon14"){
                    monsterKind = 14;
                }

                PlayerPrefs.SetInt("MonsterCount", MonsterNumber);
                PlayerPrefs.SetInt(monsterAll, monsterKind);
                PlayerPrefs.SetFloat(monsterPositionX, gameMonster.transform.position.x);
                PlayerPrefs.SetFloat(monsterPositionY, gameMonster.transform.position.y);
                PlayerPrefs.SetFloat(monsterPositionZ, gameMonster.transform.position.z);
                PlayerPrefs.SetFloat(monsterRotationX, gameMonster.transform.eulerAngles.x);
                PlayerPrefs.SetFloat(monsterRotationY, gameMonster.transform.eulerAngles.y);
                PlayerPrefs.SetFloat(monsterRotationZ, gameMonster.transform.eulerAngles.z);
                PlayerPrefs.SetFloat(monsterNowBlood, gameMonster.GetComponent<MonsterHpControl>().Hp);
                PlayerPrefs.SetFloat(monsterMaxBlood, gameMonster.GetComponent<MonsterHpControl>().MaxHp);

                MonsterNumber +=1;
            }
        }

        SceneManager.LoadScene("ChooseLevel");
    }
}
