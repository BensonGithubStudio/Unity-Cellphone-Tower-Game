using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfiniteSceneSave : MonoBehaviour
{
    public bool SaveGame;
    public bool HaveSaveGame;

    [Header("遊戲物件資料")]
    public Image BombColdImage;
    public Image FreezeColdImage;
    public GameObject[] TowerPosition;

    // Start is called before the first frame update
    void Start()
    {
        SaveGame = false;
        HaveSaveGame = false;

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



        SceneManager.LoadScene("ChooseLevel");
    }
}
