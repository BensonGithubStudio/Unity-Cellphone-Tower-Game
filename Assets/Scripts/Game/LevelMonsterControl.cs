using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMonsterControl : MonoBehaviour
{
    [Header("存檔設定")]
    public string NextLevel1;
    public string NextLevel2;

    [Header("遊戲資訊")]
    public float GameTime_float;
    public float GameTime_int;
    public int NowGameWave;
    public bool CanCallWave;
    public bool CanCallNextWave;
    public bool HaveEnemy;
    public bool IsPeace;

    [Header("遊戲設定")]
    public GameObject EnemyAppearPosition1;
    public GameObject EnemyAppearPosition2;
    public GameObject EnemyAppearPosition3;
    public GameObject EnemyAppearPosition4;
    public GameObject EnemyAppearPosition5;
    public float NextWaveWaitingTime;

    [Header("遊戲物件")]
    public Text WaveStartButtonText;
    public GameObject WaveHintText;
    public GameObject GameWinHint;

    [Header("第一波")]
    public GameObject EnemyKind1;
    public int EnemyCount1;

    [Header("第二波")]
    public GameObject EnemyKind2;
    public int EnemyCount2;

    [Header("第三波")]
    public GameObject EnemyKind3;
    public int EnemyCount3;

    [Header("第四波")]
    public GameObject EnemyKind4;
    public int EnemyCount4;

    [Header("第五波")]
    public GameObject EnemyKind5;
    public int EnemyCount5;

    [Header("第六波")]
    public GameObject EnemyKind6;
    public int EnemyCount6;

    [Header("第七波")]
    public GameObject EnemyKind7;
    public int EnemyCount7;

    [Header("第八波")]
    public GameObject EnemyKind8;
    public int EnemyCount8;

    [Header("第九波")]
    public GameObject EnemyKind9;
    public int EnemyCount9;

    [Header("第十波")]
    public GameObject EnemyKind10;
    public GameObject EnemyKind10_1;
    public int EnemyCount10;

    [Header("第十一波")]
    public GameObject EnemyKind11;
    public GameObject EnemyKind11_1;
    public int EnemyCount11;

    [Header("第十二波")]
    public GameObject EnemyKind12;
    public GameObject EnemyKind12_1;
    public int EnemyCount12;

    [Header("第十三波")]
    public GameObject EnemyKind13;
    public GameObject EnemyKind13_1;
    public int EnemyCount13;

    [Header("第十四波")]
    public GameObject EnemyKind14;
    public GameObject EnemyKind14_1;
    public int EnemyCount14;

    [Header("第十五波")]
    public GameObject EnemyKind15;
    public GameObject EnemyKind15_1;
    public int EnemyCount15;

    [Header("第十六波")]
    public GameObject EnemyKind16;
    public GameObject EnemyKind16_1;
    public int EnemyCount16;

    [Header("第十七波")]
    public GameObject EnemyKind17;
    public GameObject EnemyKind17_1;
    public int EnemyCount17;

    [Header("第十八波")]
    public GameObject EnemyKind18;
    public GameObject EnemyKind18_1;
    public int EnemyCount18;

    [Header("第十九波")]
    public GameObject EnemyKind19;
    public GameObject EnemyKind19_1;
    public int EnemyCount19;

    [Header("第二十波")]
    public GameObject EnemyKind20;
    public GameObject EnemyKind20_1;
    public int EnemyCount20;

    [Header("第二十一波")]
    public GameObject EnemyKind21;
    public GameObject EnemyKind21_1;
    public GameObject EnemyKind21_2;
    public int EnemyCount21;

    [Header("第二十二波")]
    public GameObject EnemyKind22;
     public GameObject EnemyKind22_1;
    public GameObject EnemyKind22_2;
    public int EnemyCount22;

    [Header("第二十三波")]
    public GameObject EnemyKind23;
     public GameObject EnemyKind23_1;
    public GameObject EnemyKind23_2;
    public int EnemyCount23;

    [Header("第二十四波")]
    public GameObject EnemyKind24;
     public GameObject EnemyKind24_1;
    public GameObject EnemyKind24_2;
    public int EnemyCount24;

    [Header("第二十五波")]
    public GameObject EnemyKind25;
     public GameObject EnemyKind25_1;
    public GameObject EnemyKind25_2;
    public GameObject EnemyBoss;
    public int EnemyCount25;

    // Start is called before the first frame update
    void Start()
    {
        GameTime_float = 0f;
        GameTime_int = 0;
        NowGameWave = 0;
        CanCallWave = false;
        CanCallNextWave = true;
        WaveHintText.SetActive(false);
        GameWinHint.SetActive(false);
    }

    public void OnClickWaveStart(){
        if(IsPeace){
            GameWinHint.SetActive(true);
        }else if(WaveStartButtonText != null){
            if(CanCallNextWave){
                if(NowGameWave < 25){
                    if(HaveEnemy == false){
                        WaveStartButtonText.text = "下一波";
                        NowGameWave += 1;
                        CanCallWave = true;
                        CanCallNextWave = false;
                    }
                }else{
                    if(this.gameObject.GetComponent<HeartControl>().Heart > 0){
                        if(HaveEnemy == false){
                            GameWinHint.SetActive(true);

                            string a = this.gameObject.GetComponent<GameButton>().ThisScene;
                            PlayerPrefs.SetString(a, "IsWin");
                        }
                    }
                }
            }
        }
    }

    void DestroyWaveText(){
        WaveHintText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            string a = this.gameObject.GetComponent<GameButton>().ThisScene;
            PlayerPrefs.SetString(a, "IsWin");
        }

        GameTime_float += Time.deltaTime;
        GameTime_int = (int)GameTime_float;

        if(CanCallWave){
            InvokeRepeating("EnemyAttack", 0, 0.5f);
            WaveHintText.SetActive(false);
            WaveHintText.SetActive(true);
            Invoke("DestroyWaveText", 2.2f);
            WaveHintText.GetComponent<Text>().text = "第 " + NowGameWave + " 波";
            CanCallWave = false;
        }
        if(GameObject.FindGameObjectWithTag("Enemy") == null){
            HaveEnemy = false;
        }else{
            HaveEnemy = true;
        }
    }

    void EnemyAttack(){
        if(NowGameWave == 1){
            if(EnemyCount1 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind1, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind1, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind1, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind1, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind1, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount1 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 2){
            if(EnemyCount2 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind2, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind2, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind2, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind2, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind2, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount2 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 3){
            if(EnemyCount3 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind3, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind3, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind3, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind3, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind3, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount3 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 4){
            if(EnemyCount4 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind4, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind4, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind4, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind4, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind4, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount4 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 5){
            if(EnemyCount5 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind5, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind5, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind5, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind5, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind5, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount5 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 6){
            if(EnemyCount6 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind6, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind6, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind6, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind6, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind6, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount6 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 7){
            if(EnemyCount7 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind7, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind7, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind7, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind7, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind7, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount7 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 8){
            if(EnemyCount8 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind8, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind8, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind8, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind8, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind8, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount8 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 9){
            if(EnemyCount9 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind9, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind9, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind9, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind9, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind9, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                EnemyCount9 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 10){
            if(EnemyCount10 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind10, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind10, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind10, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind10, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind10, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount10 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 11){
            if(EnemyCount11 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind11, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind11, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind11, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind11, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind11, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount11 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 12){
            if(EnemyCount12 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind12, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind12, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind12, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind12, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind12, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount12 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 13){
            if(EnemyCount13 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind13, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind13, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind13, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind13, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind13, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount13 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 14){
            if(EnemyCount14 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind14, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind14, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind14, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind14, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind14, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount14 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 15){
            if(EnemyCount15 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind15, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind15, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind15, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind15, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind15, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount15 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 16){
            if(EnemyCount16 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind16, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind16, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind16, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind16, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind16, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount16 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;

            }
        }
        if(NowGameWave == 17){
            if(EnemyCount17 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind17, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind17, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind17, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind17, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind17, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount17 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 18){
            if(EnemyCount18 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind18, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind18, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind18, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind18, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind18, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount18 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 19){
            if(EnemyCount19 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind19, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind19, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind19, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind19, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind19, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount19 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 20){
            if(EnemyCount20 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind20, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind20, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind20, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind20, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind20, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount20 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 21){
            if(EnemyCount21 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind21, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind21, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind21, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind21, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind21, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount21 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 22){
            if(EnemyCount22 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind22, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind22, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind22, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind22, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind22, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount22 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 23){
            if(EnemyCount23 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind23, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind23, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind23, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind23, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind23, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount23 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 24){
            if(EnemyCount24 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind24, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind24, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind24, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind24, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind24, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount24 -= 1;
            } else {
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
        if(NowGameWave == 25){
            if(EnemyCount25 > 0){
                if(EnemyAppearPosition1 != null){
                    Instantiate(EnemyKind25, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition2 != null){
                    Instantiate(EnemyKind25, EnemyAppearPosition2.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition3 != null){
                    Instantiate(EnemyKind25, EnemyAppearPosition3.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition4 != null){
                    Instantiate(EnemyKind25, EnemyAppearPosition4.transform.position, Quaternion.identity);
                }
                if(EnemyAppearPosition5 != null){
                    Instantiate(EnemyKind25, EnemyAppearPosition5.transform.position, Quaternion.identity);
                }
                Invoke("EnemyAttackTwice", 0.15f);
                EnemyCount25 -= 1;
            } else {
                if(EnemyBoss != null){
                    Instantiate(EnemyBoss, EnemyAppearPosition1.transform.position, Quaternion.identity);
                }
                CancelInvoke("EnemyAttack");
                CanCallNextWave = true;
            }
        }
    }

    void EnemyAttackTwice(){
        if(NowGameWave == 10){
            if(EnemyAppearPosition1 != null && EnemyKind10_1 != null){
                Instantiate(EnemyKind10_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind10_1 != null){
                Instantiate(EnemyKind10_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind10_1 != null){
                Instantiate(EnemyKind10_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind10_1 != null){
                Instantiate(EnemyKind10_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind10_1 != null){
                Instantiate(EnemyKind10_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 11){
            if(EnemyAppearPosition1 != null && EnemyKind11_1 != null){
                Instantiate(EnemyKind11_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind11_1 != null){
                Instantiate(EnemyKind11_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind11_1 != null){
                Instantiate(EnemyKind11_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind11_1 != null){
                Instantiate(EnemyKind11_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind11_1 != null){
                Instantiate(EnemyKind11_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 12){
            if(EnemyAppearPosition1 != null && EnemyKind12_1 != null){
                Instantiate(EnemyKind12_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind12_1 != null){
                Instantiate(EnemyKind12_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind12_1 != null){
                Instantiate(EnemyKind12_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind12_1 != null){
                Instantiate(EnemyKind12_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind12_1 != null){
                Instantiate(EnemyKind12_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 13){
            if(EnemyAppearPosition1 != null && EnemyKind13_1 != null){
                Instantiate(EnemyKind13_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind13_1 != null){
                Instantiate(EnemyKind13_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind13_1 != null){
                Instantiate(EnemyKind13_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind13_1 != null){
                Instantiate(EnemyKind13_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind13_1 != null){
                Instantiate(EnemyKind13_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 14){
            if(EnemyAppearPosition1 != null && EnemyKind14_1 != null){
                Instantiate(EnemyKind14_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind14_1 != null){
                Instantiate(EnemyKind14_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind14_1 != null){
                Instantiate(EnemyKind14_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind14_1 != null){
                Instantiate(EnemyKind14_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind14_1 != null){
                Instantiate(EnemyKind14_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 15){
            if(EnemyAppearPosition1 != null && EnemyKind15_1 != null){
                Instantiate(EnemyKind15_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind15_1 != null){
                Instantiate(EnemyKind15_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind15_1 != null){
                Instantiate(EnemyKind15_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind15_1 != null){
                Instantiate(EnemyKind15_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind15_1 != null){
                Instantiate(EnemyKind15_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 16){
            if(EnemyAppearPosition1 != null && EnemyKind16_1 != null){
                Instantiate(EnemyKind16_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind16_1 != null){
                Instantiate(EnemyKind16_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind16_1 != null){
                Instantiate(EnemyKind16_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind16_1 != null){
                Instantiate(EnemyKind16_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind16_1 != null){
                Instantiate(EnemyKind16_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 17){
            if(EnemyAppearPosition1 != null && EnemyKind17_1 != null){
                Instantiate(EnemyKind17_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind17_1 != null){
                Instantiate(EnemyKind17_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind17_1 != null){
                Instantiate(EnemyKind17_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind17_1 != null){
                Instantiate(EnemyKind17_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind17_1 != null){
                Instantiate(EnemyKind17_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 18){
            if(EnemyAppearPosition1 != null && EnemyKind18_1 != null){
                Instantiate(EnemyKind18_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind18_1 != null){
                Instantiate(EnemyKind18_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind18_1 != null){
                Instantiate(EnemyKind18_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind18_1 != null){
                Instantiate(EnemyKind18_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind18_1 != null){
                Instantiate(EnemyKind18_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 19){
            if(EnemyAppearPosition1 != null && EnemyKind19_1 != null){
                Instantiate(EnemyKind19_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind19_1 != null){
                Instantiate(EnemyKind19_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind19_1 != null){
                Instantiate(EnemyKind19_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind19_1 != null){
                Instantiate(EnemyKind19_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind19_1 != null){
                Instantiate(EnemyKind19_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 20){
            if(EnemyAppearPosition1 != null && EnemyKind20_1 != null){
                Instantiate(EnemyKind20_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind20_1 != null){
                Instantiate(EnemyKind20_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind20_1 != null){
                Instantiate(EnemyKind20_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind20_1 != null){
                Instantiate(EnemyKind20_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind20_1 != null){
                Instantiate(EnemyKind20_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 21){
            if(EnemyAppearPosition1 != null && EnemyKind21_1 != null){
                Instantiate(EnemyKind21_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind21_1 != null){
                Instantiate(EnemyKind21_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind21_1 != null){
                Instantiate(EnemyKind21_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind21_1 != null){
                Instantiate(EnemyKind21_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind21_1 != null){
                Instantiate(EnemyKind21_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
            Invoke("EnemyAttackTrible", 0.15f);
        }
        if(NowGameWave == 22){
            if(EnemyAppearPosition1 != null && EnemyKind22_1 != null){
                Instantiate(EnemyKind22_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind22_1 != null){
                Instantiate(EnemyKind22_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind22_1 != null){
                Instantiate(EnemyKind22_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind22_1 != null){
                Instantiate(EnemyKind22_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind22_1 != null){
                Instantiate(EnemyKind22_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
            Invoke("EnemyAttackTrible", 0.15f);
        }
        if(NowGameWave == 23){
            if(EnemyAppearPosition1 != null && EnemyKind23_1 != null){
                Instantiate(EnemyKind23_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind23_1 != null){
                Instantiate(EnemyKind23_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind23_1 != null){
                Instantiate(EnemyKind23_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind23_1 != null){
                Instantiate(EnemyKind23_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind23_1 != null){
                Instantiate(EnemyKind23_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
            Invoke("EnemyAttackTrible", 0.15f);
        }
        if(NowGameWave == 24){
            if(EnemyAppearPosition1 != null && EnemyKind24_1 != null){
                Instantiate(EnemyKind24_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind24_1 != null){
                Instantiate(EnemyKind24_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind24_1 != null){
                Instantiate(EnemyKind24_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind24_1 != null){
                Instantiate(EnemyKind24_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind24_1 != null){
                Instantiate(EnemyKind24_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
            Invoke("EnemyAttackTrible", 0.15f);
        }
        if(NowGameWave == 25){
            if(EnemyAppearPosition1 != null && EnemyKind25_1 != null){
                Instantiate(EnemyKind25_1, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind25_1 != null){
                Instantiate(EnemyKind25_1, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind25_1 != null){
                Instantiate(EnemyKind25_1, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind25_1 != null){
                Instantiate(EnemyKind25_1, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind25_1 != null){
                Instantiate(EnemyKind25_1, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
            Invoke("EnemyAttackTrible", 0.15f);
        }
    }

    void EnemyAttackTrible(){
        if(NowGameWave == 21){
            if(EnemyAppearPosition1 != null && EnemyKind21_2 != null){
                Instantiate(EnemyKind21_2, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind21_2 != null){
                Instantiate(EnemyKind21_2, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind21_2 != null){
                Instantiate(EnemyKind21_2, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind21_2 != null){
                Instantiate(EnemyKind21_2, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind21_2 != null){
                Instantiate(EnemyKind21_2, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 22){
            if(EnemyAppearPosition1 != null && EnemyKind22_2 != null){
                Instantiate(EnemyKind22_2, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind22_2 != null){
                Instantiate(EnemyKind22_2, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind22_2 != null){
                Instantiate(EnemyKind22_2, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind22_2 != null){
                Instantiate(EnemyKind22_2, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind22_2 != null){
                Instantiate(EnemyKind22_2, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 23){
            if(EnemyAppearPosition1 != null && EnemyKind23_2 != null){
                Instantiate(EnemyKind23_2, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind23_2 != null){
                Instantiate(EnemyKind23_2, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind23_2 != null){
                Instantiate(EnemyKind23_2, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind23_2 != null){
                Instantiate(EnemyKind23_2, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind23_2 != null){
                Instantiate(EnemyKind23_2, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 24){
            if(EnemyAppearPosition1 != null && EnemyKind24_2 != null){
                Instantiate(EnemyKind24_2, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind24_2 != null){
                Instantiate(EnemyKind24_2, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind24_2 != null){
                Instantiate(EnemyKind24_2, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind24_2 != null){
                Instantiate(EnemyKind24_2, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind24_2 != null){
                Instantiate(EnemyKind24_2, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
        if(NowGameWave == 25){
            if(EnemyAppearPosition1 != null && EnemyKind25_2 != null){
                Instantiate(EnemyKind25_2, EnemyAppearPosition1.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition2 != null && EnemyKind25_2 != null){
                Instantiate(EnemyKind25_2, EnemyAppearPosition2.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition3 != null && EnemyKind25_2 != null){
                Instantiate(EnemyKind25_2, EnemyAppearPosition3.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition4 != null && EnemyKind25_2 != null){
                Instantiate(EnemyKind25_2, EnemyAppearPosition4.transform.position, Quaternion.identity);
            }
            if(EnemyAppearPosition5 != null && EnemyKind25_2 != null){
                Instantiate(EnemyKind25_2, EnemyAppearPosition5.transform.position, Quaternion.identity);
            }
        }
    }
}