using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    public string ThisScene;
    public Animator SettingAnimator;
    public bool SettingIsOpen;
    public bool SettingSoundIsOpen;

    public AudioSource ClickButtonAudioSource;
    public AudioClip ClickButtonSound;

    public GameObject CloseGameAssure;
    public GameObject TowerPosition;

    public GameObject InfiniteSetting;
    public bool RoadCanBlock;
    public GameObject RoadCanBlockImage;

    public GameObject MoneyInfiniteImage;
    public bool MoneyInfinite;
    public GameObject HeartInfiniteImage;
    public bool HeartInfinite;

    void Start(){
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void OnClickCloseGameAssure(){
        if(CloseGameAssure.activeSelf == false){
            CloseGameAssure.SetActive(true);
            Time.timeScale = 0;
            TowerPosition.SetActive(false);
        }else{
            CloseGameAssure.SetActive(false);
            Time.timeScale = 1;
            TowerPosition.SetActive(true);
        }
    }
    public void OnClickCloseGameAndSave(){
        this.gameObject.GetComponent<InfiniteSceneSave>().SaveGame = true;
        Time.timeScale = 1;
    }

    private void OnApplicationQuit() {
        this.gameObject.GetComponent<InfiniteSceneSave>().SaveGame = true;
        Time.timeScale = 1;
    }

    public void OnClickCloseGameAndDontSave(){
        PlayerPrefs.DeleteKey("InfiniteScene");
        ClickButtonAudioSource.pitch = 1;
        ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
        Time.timeScale = 1;
        SceneManager.LoadScene("ChooseLevel");
    }

    public void OnClickExitGame(){
        ClickButtonAudioSource.pitch = 1;
        ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
        SceneManager.LoadScene("ChooseLevel");
    }
    
    public void OnClickRestartGame(){
         SceneManager.LoadScene(ThisScene);
         ClickButtonAudioSource.pitch = 1;
         ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
    }

    public void OnClickSetting(){
        if(SettingIsOpen){
            ClickButtonAudioSource.pitch = 1;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SettingAnimator.SetBool("IsOpen", false);
            SettingAnimator.SetBool("IsSoundOpen", false);
            SettingIsOpen = false;
            SettingSoundIsOpen = false;
        }else{
            ClickButtonAudioSource.pitch = 1;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SettingAnimator.SetBool("IsOpen", true);
            SettingIsOpen = true;
        }
    }

    public void OnClickSettingSound(){
        if(SettingSoundIsOpen){
            ClickButtonAudioSource.pitch = 1;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SettingAnimator.SetBool("IsSoundOpen", false);
            SettingSoundIsOpen = false;
        }else{
            ClickButtonAudioSource.pitch = 1;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SettingAnimator.SetBool("IsSoundOpen", true);
            SettingSoundIsOpen = true;
        }
    }

    public void OnClickSettingScreenQuality(){
        ClickButtonAudioSource.pitch = 1;
        ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
    }

    public void OnClickInfiniteSetting(){
        if(InfiniteSetting.activeSelf == true){
            Time.timeScale = 1;
            TowerPosition.SetActive(true);
            InfiniteSetting.SetActive(false);
        }else{
            Time.timeScale = 0;
            TowerPosition.SetActive(false);
            InfiniteSetting.SetActive(true);
        }
    }

    public void OnClickRoadBlockSetting(){
        if(RoadCanBlock){
            RoadCanBlockImage.SetActive(false);
            RoadCanBlock = false;
        }else{
            RoadCanBlockImage.SetActive(true);
            RoadCanBlock = true;
        }
    }

    public void OnClickMoneyInfinite(){
        if(MoneyInfinite){
            MoneyInfiniteImage.SetActive(false);
            MoneyInfinite = false;
        }else{
            MoneyInfiniteImage.SetActive(true);
            MoneyInfinite = true;
        }
    }

    public void OnClickHeartInfinite(){
        if(HeartInfinite){
            HeartInfiniteImage.SetActive(false);
            HeartInfinite = false;
        }else{
            HeartInfiniteImage.SetActive(true);
            HeartInfinite = true;
        }
    }
}
