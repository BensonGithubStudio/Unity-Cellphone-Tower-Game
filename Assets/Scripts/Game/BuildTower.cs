using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildTower : MonoBehaviour
{
    public bool MouseIsOver;
    public static bool IsBuying;
    public Color ClickColor;
    public Color UnClickColor;
    public Color LowerLevel10Color;
    public Color LowerLevel50Color;
    public Color LowerLevel100Color;
    public Color LowerLevel200Color;
    public Color HigherLevel200Color;

    public GameObject GameControlGameObject;
    public GameObject BuyTowerInfo;
    public GameObject MyselfGameObject;
    
    public GameObject CancelPanel;

    [Header("武器庫管理")]
    public AudioSource GameSoundAudioSource;
    public AudioClip BuildTowerSound;
    public AudioClip PressBuildTowerButton;
    public AudioClip PressCancelBuildTowerButton;
    public GameObject CloneArmy;
    public GameObject SingleTower;
    public int SingleTowerPrice;
    public GameObject BombTower;
    public int BombTowerPrice;
    public GameObject LaserTower;
    public int LaserTowerPrice;
    public GameObject QuickTower;
    public int QuickTowerPrice;

    void OnMouseOver() {
        MouseIsOver = true;
    }
    void OnMouseExit() {
        MouseIsOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        BuyTowerInfo.SetActive(false);
        CancelPanel.SetActive(false);
        IsBuying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MouseIsOver){
            if(Input.GetMouseButton(0)){
                if(IsBuying == false && CloneArmy == null){
                    GameSoundAudioSource.pitch = 3;
                    GameSoundAudioSource.PlayOneShot(PressBuildTowerButton);
                    this.gameObject.GetComponent<Renderer>().material.color = ClickColor;
                    BuyTowerInfo.SetActive(true);
                    CancelPanel.SetActive(true);
                    IsBuying = true;
                }
            }else {
                this.gameObject.GetComponent<Renderer>().material.color = UnClickColor;
            }
        }else {
            this.gameObject.GetComponent<Renderer>().material.color = UnClickColor;
        }
        if(GameControlGameObject.GetComponent<GameButton>().ThisScene == "Infinite Level"){
            if(CloneArmy == null){
                this.gameObject.GetComponent<NavMeshObstacle>().enabled = false;
            }else{
                this.gameObject.GetComponent<NavMeshObstacle>().enabled = true;
            }
        }

        if(CloneArmy != null){
            int a = CloneArmy.GetComponentInChildren<TowerShoot>().TowerLevel;
            if(a <= 10){
                this.gameObject.GetComponent<Renderer>().material.color = LowerLevel10Color;
            }else if(a <= 50){
                this.gameObject.GetComponent<Renderer>().material.color = LowerLevel50Color;
            }else if(a <= 100){
                this.gameObject.GetComponent<Renderer>().material.color = LowerLevel100Color;
            }else if(a <= 200){
                this.gameObject.GetComponent<Renderer>().material.color = LowerLevel200Color;
            }else {
                this.gameObject.GetComponent<Renderer>().material.color = HigherLevel200Color;
            }
        }
    }

    public void OnClickCancelBuyTower(){
        GameSoundAudioSource.pitch = 0.7f;
        GameSoundAudioSource.PlayOneShot(PressCancelBuildTowerButton);
        BuyTowerInfo.SetActive(false);
        CancelPanel.SetActive(false);
        IsBuying = false;
    }
    public void OnClickBuyTower_Single(){
        if(GameControlGameObject.GetComponent<MoneyControl>().Money >= SingleTowerPrice){
            GameSoundAudioSource.pitch = 1.3f;
            GameSoundAudioSource.PlayOneShot(BuildTowerSound);
            CloneArmy = Instantiate(SingleTower, MyselfGameObject.transform.position, Quaternion.identity);
            GameControlGameObject.GetComponent<MoneyControl>().Money -= SingleTowerPrice;
            BuyTowerInfo.SetActive(false);
            IsBuying = false;
        }
    }
     public void OnClickBuyTower_Bomb(){
        if(GameControlGameObject.GetComponent<MoneyControl>().Money >= BombTowerPrice){
            GameSoundAudioSource.pitch = 1.3f;
            GameSoundAudioSource.PlayOneShot(BuildTowerSound);
            CloneArmy = Instantiate(BombTower, MyselfGameObject.transform.position, Quaternion.identity);
            GameControlGameObject.GetComponent<MoneyControl>().Money -= BombTowerPrice;
            BuyTowerInfo.SetActive(false);
            IsBuying = false;
        }
    }
    public void OnClickBuyTower_Laser(){
        if(GameControlGameObject.GetComponent<MoneyControl>().Money >= LaserTowerPrice){
            GameSoundAudioSource.pitch = 1.3f;
            GameSoundAudioSource.PlayOneShot(BuildTowerSound);
            CloneArmy = Instantiate(LaserTower, MyselfGameObject.transform.position, Quaternion.identity);
            GameControlGameObject.GetComponent<MoneyControl>().Money -= LaserTowerPrice;
            BuyTowerInfo.SetActive(false);
            IsBuying = false;
        }
    }
    public void OnClickBuyTower_Quick(){
        if(GameControlGameObject.GetComponent<MoneyControl>().Money >= QuickTowerPrice){
            GameSoundAudioSource.pitch = 1.3f;
            GameSoundAudioSource.PlayOneShot(BuildTowerSound);
            CloneArmy = Instantiate(QuickTower, MyselfGameObject.transform.position, Quaternion.identity);
            GameControlGameObject.GetComponent<MoneyControl>().Money -= QuickTowerPrice;
            BuyTowerInfo.SetActive(false);
            IsBuying = false;
        }
    } 
}
