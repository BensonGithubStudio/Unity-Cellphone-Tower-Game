using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetting : MonoBehaviour
{
    public string ThisScene;
    public Slider QualitySettingSlider;
    void Start()
    {
        if(ThisScene == "Awake Game"){
            if(!PlayerPrefs.HasKey("Quality")){
                QualitySettings.SetQualityLevel(2);
            }else{
                if(PlayerPrefs.GetString("Quality") == "Very Low"){
                    QualitySettings.SetQualityLevel(0);
                }else if(PlayerPrefs.GetString("Quality") == "Low"){
                    QualitySettings.SetQualityLevel(1);
                }else if(PlayerPrefs.GetString("Quality") == "Medium"){
                    QualitySettings.SetQualityLevel(2);
                }else if(PlayerPrefs.GetString("Quality") == "High"){
                    QualitySettings.SetQualityLevel(3);
                }else if(PlayerPrefs.GetString("Quality") == "Very High"){
                    QualitySettings.SetQualityLevel(4);
                }else if(PlayerPrefs.GetString("Quality") == "Ultra"){
                    QualitySettings.SetQualityLevel(5);
                }
            }
        }else if(ThisScene == "Green"){
            if(!PlayerPrefs.HasKey("Quality")){
                QualitySettings.SetQualityLevel(2);
            }else{
                if(PlayerPrefs.GetString("Quality") == "Very Low"){
                    QualitySettings.SetQualityLevel(0);
                }else if(PlayerPrefs.GetString("Quality") == "Low"){
                    QualitySettings.SetQualityLevel(1);
                }else if(PlayerPrefs.GetString("Quality") == "Medium"){
                    QualitySettings.SetQualityLevel(2);
                }else if(PlayerPrefs.GetString("Quality") == "High"){
                    QualitySettings.SetQualityLevel(3);
                }else if(PlayerPrefs.GetString("Quality") == "Very High"){
                    QualitySettings.SetQualityLevel(4);
                }else if(PlayerPrefs.GetString("Quality") == "Ultra"){
                    QualitySettings.SetQualityLevel(5);
                }
            }
        }else if(ThisScene == "ChooseLevel"){
            if(!PlayerPrefs.HasKey("Quality")){
                QualitySettings.SetQualityLevel(5);
            }else{
                if(PlayerPrefs.GetString("Quality") == "Very Low"){
                    QualitySettings.SetQualityLevel(0);
                    QualitySettingSlider.value = 0;
                }else if(PlayerPrefs.GetString("Quality") == "Low"){
                    QualitySettings.SetQualityLevel(1);
                    QualitySettingSlider.value = 1;
                }else if(PlayerPrefs.GetString("Quality") == "Medium"){
                    QualitySettings.SetQualityLevel(2);
                    QualitySettingSlider.value = 2;
                }else if(PlayerPrefs.GetString("Quality") == "High"){
                    QualitySettings.SetQualityLevel(3);
                    QualitySettingSlider.value = 3;
                }else if(PlayerPrefs.GetString("Quality") == "Very High"){
                    QualitySettings.SetQualityLevel(4);
                    QualitySettingSlider.value = 4;
                }else if(PlayerPrefs.GetString("Quality") == "Ultra"){
                    QualitySettings.SetQualityLevel(5);
                    QualitySettingSlider.value = 5;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ThisScene == "ChooseLevel"){
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
    }
}
