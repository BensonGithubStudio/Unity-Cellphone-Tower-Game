using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteLevelControl : MonoBehaviour
{
    [Header("敵人種類")]
    public GameObject[] Monster;


    [Header("關卡管理")]
    public GameObject AppearPosition;
    public int EnemyAppearTime;
    public int EnemyKind;
    public float EnemyNumber;
    public int EnemyBlood;
    public int GetMoney;

    [Header("動畫管理")]
    public Animator MonsterIntroduceAnimator;

    [Header("其他資訊管理")]
    public bool CanNextWave;
    public int NowWave;
    public GameObject WaveText;
    public GameObject TimeCountText;
    public Text StartOrNextWaveText;
    public Text SpeedUpText;
    public GameObject PauseImage;
    public GameObject StartImage;

    // Start is called before the first frame update
    void Start()
    {
        EnemyAppearTime = 40;
        InvokeRepeating("TimeCount", 0, 1);
        NowWave = 0;
        WaveText.SetActive(false);
    }

    void TimeCount(){
        EnemyAppearTime -= 1;
        if(EnemyAppearTime > 0){
            TimeCountText.GetComponent<Text>().text = "距離下一波還有" + EnemyAppearTime + "秒";
        }

        if(CanNextWave){
            CancelInvoke("DestroyWaveText");
            CancelInvoke("MakeEnemy");
            
            EnemyBlood += 200;
            GetMoney += 5;
            EnemyNumber = Random.Range(5, 30);
            EnemyKind = Random.Range(0, 14);
            EnemyAppearTime = 30;
            TimeCountText.GetComponent<Text>().text = "距離下一波還有" + EnemyAppearTime + "秒";

            MonsterIntroduceAnimator.SetInteger("NowMonster", 0);
            MonsterIntroduceAnimator.SetInteger("NowMonster", EnemyKind + 1);
            Invoke("CancelIntroduceUIAnimation", 5);

            NowWave += 1;
            WaveText.SetActive(false);
            WaveText.SetActive(true);
            WaveText.GetComponent<Text>().text = "第" + NowWave + "波";
            Invoke("DestroyWaveText", 2.5f);
            InvokeRepeating("MakeEnemy", 0, 0.5f);
            CanNextWave = false;
        }
    }

    void CancelIntroduceUIAnimation(){
        MonsterIntroduceAnimator.SetInteger("NowMonster", 0);
    }

    void DestroyWaveText(){
        WaveText.SetActive(false);
    }

    void MakeEnemy(){
        if(EnemyNumber >0){
            GameObject a = Instantiate(Monster[EnemyKind], AppearPosition.transform.position, Quaternion.identity);
            a.GetComponent<MonsterHpControl>().MaxHp = EnemyBlood;
            a.GetComponent<MonsterHpControl>().EarnMoney = GetMoney;
            EnemyNumber -= 1;
        }else{
            CancelInvoke("MakeEnemy");
        }
    }

    public void OnClickNextWave(){
        EnemyAppearTime = 0;
        StartOrNextWaveText.text = "下一波";
    }

    public void OnClickPause(){
        if(Time.timeScale == 1 || Time.timeScale == 2){
            Time.timeScale = 0;
        }else{
            Time.timeScale = 1;
        }
    }

    public void OnClickSpeedUp(){
        if(Time.timeScale == 1){
            Time.timeScale = 2;
        }else if(Time.timeScale == 2){
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyAppearTime <= 0){
            CanNextWave = true;
        }else{
            CanNextWave = false;
        }

        if(Time.timeScale == 0){
            PauseImage.SetActive(false);
            StartImage.SetActive(true);
            SpeedUpText.text = " ";
        }else if(Time.timeScale == 1){
            StartImage.SetActive(false);
            PauseImage.SetActive(true);
            SpeedUpText.text = "x2";
        }else{
            StartImage.SetActive(false);
            PauseImage.SetActive(true);
            SpeedUpText.text = "x1";
        }
    }
}
