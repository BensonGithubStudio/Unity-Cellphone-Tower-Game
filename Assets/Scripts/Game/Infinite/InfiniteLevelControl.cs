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

    [Header("其他資訊管理")]
    public bool CanNextWave;
    public int NowWave;
    public GameObject WaveText;
    public GameObject TimeCountText;

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
            EnemyBlood += 10;
            EnemyNumber = Random.Range(5, 30);
            EnemyKind = Random.Range(0, 14);
            EnemyAppearTime = 30;
            TimeCountText.GetComponent<Text>().text = "距離下一波還有" + EnemyAppearTime + "秒";

            NowWave += 1;
            WaveText.SetActive(false);
            WaveText.SetActive(true);
            WaveText.GetComponent<Text>().text = "第" + NowWave + "波";
            Invoke("DestroyWaveText", 2.5f);
            InvokeRepeating("MakeEnemy", 0, 0.5f);
            CanNextWave = false;
        }
    }

    void DestroyWaveText(){
        WaveText.SetActive(false);
    }

    void MakeEnemy(){
        if(EnemyNumber >0){
            GameObject a = Instantiate(Monster[EnemyKind], AppearPosition.transform.position, Quaternion.identity);
            a.GetComponent<MonsterHpControl>().MaxHp = EnemyBlood;
            EnemyNumber -= 1;
        }else{
            CancelInvoke("MakeEnemy");
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
    }
}
