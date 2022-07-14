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

    public void OnClickExitGame(){
        SceneManager.LoadScene("ChooseLevel");
        ClickButtonAudioSource.pitch = 1;
        ClickButtonAudioSource.PlayOneShot(ClickButtonSound);
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
}
