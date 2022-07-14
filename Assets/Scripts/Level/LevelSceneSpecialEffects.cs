using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSceneSpecialEffects : MonoBehaviour
{
    public Text ToBeContinueText;

    public Animator BackgroundImageEffectAnimator;
    public GameObject BackgroundContent;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ToBeContinueTextCheck" ,0 , 0.5f);
    }

    void Update(){
        if(BackgroundContent.transform.localPosition.x >= -1100){
            BackgroundImageEffectAnimator.SetBool("IsRed", false);
            BackgroundImageEffectAnimator.SetBool("IsGreen", false);
            BackgroundImageEffectAnimator.SetBool("IsBlue", false);
        }
        if(BackgroundContent.transform.localPosition.x < -1100 && BackgroundContent.transform.localPosition.x >= -2300){
            BackgroundImageEffectAnimator.SetBool("IsRed", true);
            BackgroundImageEffectAnimator.SetBool("IsGreen", false);
            BackgroundImageEffectAnimator.SetBool("IsBlue", false);
        }
        if(BackgroundContent.transform.localPosition.x < -2300 && BackgroundContent.transform.localPosition.x >= -3600){
            BackgroundImageEffectAnimator.SetBool("IsRed", false);
            BackgroundImageEffectAnimator.SetBool("IsGreen", true);
            BackgroundImageEffectAnimator.SetBool("IsBlue", false);
        }
        if(BackgroundContent.transform.localPosition.x < -3600){
            BackgroundImageEffectAnimator.SetBool("IsRed", false);
            BackgroundImageEffectAnimator.SetBool("IsGreen", false);
            BackgroundImageEffectAnimator.SetBool("IsBlue", true);
        }
    }

    void ToBeContinueTextCheck(){
        if(ToBeContinueText.text == "未完待續"){
            ToBeContinueText.text = "未完待續.";
        }else if(ToBeContinueText.text == "未完待續."){
            ToBeContinueText.text = "未完待續..";
        }else if(ToBeContinueText.text == "未完待續.."){
            ToBeContinueText.text = "未完待續...";
        }else{
            ToBeContinueText.text = "未完待續";
        }
    }
}
