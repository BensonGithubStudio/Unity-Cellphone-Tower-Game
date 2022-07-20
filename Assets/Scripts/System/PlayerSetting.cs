using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetting : MonoBehaviour
{
    public string ThisScene;
    public Slider QualitySettingSlider;

    public bool CanUpdateQuality;
    public int LastValue;
    public int NowValue;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

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
                QualitySettings.SetQualityLevel(2);
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
}
