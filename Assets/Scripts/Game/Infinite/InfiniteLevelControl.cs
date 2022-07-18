using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class InfiniteLevelControl : MonoBehaviour
{
    [Header("敵人種類")]
    public GameObject[] Monster;


    [Header("關卡管理")]
    public GameObject AppearPosition;
    public AudioSource AirPlaneAudioSource;
    public AudioClip AirplaneSound;
    public int EnemyAppearTime;
    public int EnemyKind;
    public float EnemyNumber;
    public int EnemyBlood;
    public int GetMoney;

    [Header("動畫管理")]
    public Animator MonsterIntroduceAnimator;

    [Header("大招管理")]
    public Image ColdImage;
    public GameObject CleanMonsterSmoke;
    public AudioSource BombAudioSource;
    public AudioClip BombSound;

    public Image FreezeColdImage;
    public GameObject FreezeMonsterSmoke;
    public AudioSource FreezeAudioSource;
    public AudioClip FreezeSound;
    public float FreezeSoundPitch;

    [Header("其他資訊管理")]
    public bool CanNextWave;
    public bool CanPlusMoney;
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
        CanPlusMoney = false;
    }

    void TimeCount(){
        EnemyAppearTime -= 1;
        if(EnemyAppearTime > 0){
            TimeCountText.GetComponent<Text>().text = "距離下一波還有" + EnemyAppearTime + "秒";
        }

        if(CanNextWave){
            CancelInvoke("DestroyWaveText");
            CancelInvoke("MakeEnemy");
            
            if(NowWave <= 10){
                EnemyBlood += 350;
            }else if(NowWave <= 50){
                EnemyBlood += 750;
            }else if(NowWave <= 100){
                EnemyBlood += 1600;
            }else{
                EnemyBlood += 3100;
            }
            GetMoney += 5;
            EnemyNumber = Random.Range(5, 30);
            EnemyKind = Random.Range(0, 14);
            if(EnemyKind == 4){
                AirPlaneAudioSource.pitch = 1;
                AirPlaneAudioSource.PlayOneShot(AirplaneSound);
            }
            EnemyAppearTime = 30;
            TimeCountText.GetComponent<Text>().text = "距離下一波還有" + EnemyAppearTime + "秒";

            CanPlusMoney = true;

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
            if(EnemyKind == 2){
                a.GetComponent<MonsterHpControl>().MaxHp = (EnemyBlood / 2);
            }else if(EnemyKind == 4){
                if(NowWave < 20){
                    a.GetComponent<MonsterHpControl>().MaxHp = EnemyBlood;
                }else if(NowWave < 50){
                    a.GetComponent<MonsterHpControl>().MaxHp = (EnemyBlood / 2);
                }else {
                    a.GetComponent<MonsterHpControl>().MaxHp = (EnemyBlood / 4);
                }
            }else if(EnemyKind == 8){
                a.GetComponent<MonsterHpControl>().MaxHp = (EnemyBlood / 2);
            }else{
                a.GetComponent<MonsterHpControl>().MaxHp = EnemyBlood;
            }
            a.GetComponent<MonsterHpControl>().EarnMoney = GetMoney;
            EnemyNumber -= 1;
        }else{
            CancelInvoke("MakeEnemy");
        }
    }

    public void OnClickNextWave(){
        if(EnemyNumber <=0 ){
            EnemyAppearTime = 0;
            StartOrNextWaveText.text = "下一波";
        }
    }

    public void OnClickDestroyAllMonster(){
        CleanMonsterSmoke.SetActive(false);
        CleanMonsterSmoke.SetActive(true);
        BombAudioSource.pitch = 1;
        BombAudioSource.PlayOneShot(BombSound);

        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject monster in monsters){
            Destroy(monster);
        }

        ColdImage.fillAmount = 1;
        ColdImage.raycastTarget = true;
    }

    public void OnClickFreezeAllMonster(){
        FreezeMonsterSmoke.SetActive(false);
        FreezeMonsterSmoke.SetActive(true);
        FreezeAudioSource.pitch = FreezeSoundPitch;
        FreezeAudioSource.PlayOneShot(FreezeSound);

        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject monster in monsters){
            if(monster.GetComponent<NavMeshAgent>() != null){
                monster.GetComponent<NavMeshAgent>().speed = 0;
            }
        }

        Invoke("MonsterSpeed", 5);
        FreezeColdImage.fillAmount = 1;
        FreezeColdImage.raycastTarget = true;
    }

    void MonsterSpeed(){
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject monster in monsters){
            if(monster.GetComponent<NavMeshAgent>() != null){
                if(monster.GetComponent<NavMeshAgent>().speed == 0){
                    monster.GetComponent<NavMeshAgent>().speed = 10;
                }
            }
        }
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

        if(GameObject.FindGameObjectWithTag("Enemy") == null){
            if(CanPlusMoney){
                Invoke("PlusMoney", 1);
                CanPlusMoney = false;
            }
        }


        if(ColdImage.fillAmount > 0){
            if(GameObject.FindGameObjectWithTag("Enemy") != null){
                ColdImage.fillAmount -= 0.008f * Time.deltaTime;
            }
        }else{
            ColdImage.raycastTarget = false;
        }

        if(FreezeColdImage.fillAmount > 0){
            if(GameObject.FindGameObjectWithTag("Enemy") != null){
                FreezeColdImage.fillAmount -= 0.008f * Time.deltaTime;
            }
        }else{
            FreezeColdImage.raycastTarget = false;
        }
    }

    void PlusMoney(){
        this.gameObject.GetComponent<MoneyControl>().Money += (NowWave * 50);
    }
}
