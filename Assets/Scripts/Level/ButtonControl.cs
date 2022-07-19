using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public bool CanClick;

    public Animator SettingAnimator;
    public GameObject SettingImage;
    public Slider QualitySettingSlider;

    public AudioSource ClickButtonAudioSource;
    public AudioClip ClickButtonSound;

    public AudioSource BackgroundAudioSource;
    public float BackgroundVolume;




    void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        BackgroundVolume = 0;
        CanClick = true;
        if(SettingImage != null){
            SettingImage.SetActive(false);
        }
    }

    void Update(){
        if(BackgroundAudioSource != null){
            if(BackgroundVolume <= 0.5f){
                BackgroundVolume += 0.25f * Time.deltaTime;
                BackgroundAudioSource.volume = BackgroundVolume;;
            }
        }
    }

    public void OnClickExitGame(){
        Application.Quit();
    }

    public void OnClickSetting(){
        SettingImage.SetActive(true);
    }
    public void OnClickCancelSetting(){
        SettingImage.SetActive(false);

        if(QualitySettingSlider.value == 0){
            PlayerPrefs.SetString("Quality", "Very Low");
            QualitySettings.SetQualityLevel(0);
        }
        if(QualitySettingSlider.value == 1){
            PlayerPrefs.SetString("Quality", "Low");
            QualitySettings.SetQualityLevel(1);
        }
        if(QualitySettingSlider.value == 2){
            PlayerPrefs.SetString("Quality", "Medium");
            QualitySettings.SetQualityLevel(2);
        }
        if(QualitySettingSlider.value == 3){
            PlayerPrefs.SetString("Quality", "High");
            QualitySettings.SetQualityLevel(3);
        }
        if(QualitySettingSlider.value == 4){
            PlayerPrefs.SetString("Quality", "Very High");
            QualitySettings.SetQualityLevel(4);
        }
        if(QualitySettingSlider.value == 5){
            PlayerPrefs.SetString("Quality", "Ultra");
            QualitySettings.SetQualityLevel(5);
        }
    }

    public void OnClickChangeToLevelChoose(){
        ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
        SceneManager.LoadSceneAsync("ChooseLevel");
    }

    public void OnClickChangeToLevel1(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 1");
        }
    }
    public void OnClickChangeToLevel2(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 2");
        }
    }
    public void OnClickChangeToLevel3(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 3");
        }
    }
    public void OnClickChangeToLevel4(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 4");
        }
    }
    public void OnClickChangeToLevel5(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 5");
        }
    }
    public void OnClickChangeToLevel6(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 6");
        }
    }
    public void OnClickChangeToLevel7(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 7");
        }
    }
    public void OnClickChangeToLevel8(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 8");
        }
    }
    public void OnClickChangeToLevel9(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 9");
        }
    }
    public void OnClickChangeToLevel10(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 10");
        }
    }
    public void OnClickChangeToLevel11(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 11");
        }
    }
    public void OnClickChangeToLevel12(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 12");
        }
    }
    public void OnClickChangeToLevel13(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 13");
        }
    }
    public void OnClickChangeToLevel14(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 14");
        }
    }
    public void OnClickChangeToLevel15(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 15");
        }
    }
    public void OnClickChangeToLevel16(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 16");
        }
    }
    public void OnClickChangeToLevel17(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 17");
        }
    }
    public void OnClickChangeToLevel18(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 18");
        }
    }
    public void OnClickChangeToLevel19(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Level 19");
        }
    }

    public void OnClickChangeToRedLevel1(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 1");
        }
    }
    public void OnClickChangeToRedLevel2(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 2");
        }
    }
    public void OnClickChangeToRedLevel3(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 3");
        }
    }
    public void OnClickChangeToRedLevel4(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 4");
        }
    }
    public void OnClickChangeToRedLevel5(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 5");
        }
    }
    public void OnClickChangeToRedLevel6(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 6");
        }
    }
    public void OnClickChangeToRedLevel7(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 7");
        }
    }
    public void OnClickChangeToRedLevel8(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 8");
        }
    }
    public void OnClickChangeToRedLevel9(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 9");
        }
    }
    public void OnClickChangeToRedLevel10(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 10");
        }
    }
    public void OnClickChangeToRedLevel11(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 11");
        }
    }
    public void OnClickChangeToRedLevel12(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 12");
        }
    }
    public void OnClickChangeToRedLevel13(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Red Level 13");
        }
    }

    public void OnClickChangeToYellowLevel1(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Yellow Level 1");
        }
    }
    public void OnClickChangeToYellowLevel2(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Yellow Level 2");
        }
    }
    public void OnClickChangeToYellowLevel3(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Yellow Level 3");
        }
    }
     public void OnClickChangeToYellowLevel4(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Yellow Level 4");
        }
    }

    public void OnClickChangeToGreenLevel1(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Green Level 1");
        }
    }
    public void OnClickChangeToGreenLevel2(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Green Level 2");
        }
    }
    public void OnClickChangeToGreenLevel3(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Green Level 3");
        }
    }
    public void OnClickChangeToGreenLevel4(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Green Level 4");
        }
    }
    public void OnClickChangeToGreenLevel5(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Green Level 5");
        }
    }
    public void OnClickChangeToGreenLevel6(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Green Level 6");
        }
    }

    public void OnClickChangeToGrayLevel1(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Gray Level 1");
        }
    }
    public void OnClickChangeToGrayLevel2(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Gray Level 2");
        }
    }
    public void OnClickChangeToGrayLevel3(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Gray Level 3");
        }
    }
    public void OnClickChangeToGrayLevel4(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Gray Level 4");
        }
    }
    public void OnClickChangeToGrayLevel5(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Gray Level 5");
        }
    }
    public void OnClickChangeToGrayLevel6(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Gray Level 6");
        }
    }
    public void OnClickChangeToGrayLevel7(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Gray Level 7");
        }
    }

    public void OnClickChangeToOrangeLevel1(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Orange Level 1");
        }
    }
    public void OnClickChangeToOrangeLevel2(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Orange Level 2");
        }
    }
    public void OnClickChangeToOrangeLevel3(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Orange Level 3");
        }
    }
    public void OnClickChangeToOrangeLevel4(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Orange Level 4");
        }
    }

    public void OnClickChangeToInfiniteLevel(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Infinite Level");
        }
    }

    public void OnClickChangeToQuickLevel(){
        if(CanClick){
            CanClick = false;
            ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
            SceneManager.LoadSceneAsync("Quick Level");
        }
    }
}
