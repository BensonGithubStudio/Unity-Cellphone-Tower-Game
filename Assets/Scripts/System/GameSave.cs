using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSave : MonoBehaviour
{
    public GameObject CleanDataAssure;

    public GameObject [] Level;
    public GameObject [] RedLevel;
    public GameObject [] YellowLevel;
    public GameObject [] GreenLevel;
    public GameObject [] GrayLevel;
    public GameObject [] OrangeLevel;

    public GameObject InfiniteLevel;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Level 1")){
            Level[2].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 2")){
            Level[3].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 3")){
            Level[4].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 4")){
            Level[5].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 5")){
            Level[6].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 6")){
            Level[7].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 7")){
            Level[8].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 8")){
            Level[9].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 9")){
            Level[10].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 10")){
            Level[11].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 11")){
            Level[12].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 12")){
            Level[13].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 13")){
            Level[14].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 14")){
            Level[15].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Green Level 6")){
            Level[16].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 16")){
            Level[17].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 17")){
            Level[18].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Level 18")){
            Level[19].SetActive(false);
        }

        if(PlayerPrefs.HasKey("Level 8")){
            RedLevel[1].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 1")){
            RedLevel[2].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 2")){
            RedLevel[3].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 3")){
            RedLevel[4].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 4")){
            RedLevel[5].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 5")){
            RedLevel[6].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 6")){
            RedLevel[7].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 7")){
            RedLevel[8].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 8")){
            RedLevel[9].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 9")){
            RedLevel[10].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 10")){
            RedLevel[11].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 11")){
            RedLevel[12].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Red Level 12")){
            RedLevel[13].SetActive(false);
        }

        if(PlayerPrefs.HasKey("Red Level 4")){
            YellowLevel[1].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Yellow Level 1")){
            YellowLevel[2].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Yellow Level 2")){
            YellowLevel[3].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Green Level 6")){
            YellowLevel[4].SetActive(false);
        }

        if(PlayerPrefs.HasKey("Level 15") && PlayerPrefs.HasKey("Yellow Level 3")){
            GreenLevel[1].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Green Level 1")){
            GreenLevel[2].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Green Level 2")){
            GreenLevel[3].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Green Level 3")){
            GreenLevel[4].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Green Level 4")){
            GreenLevel[5].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Green Level 5")){
            GreenLevel[6].SetActive(false);
        }

        if(PlayerPrefs.HasKey("Red Level 9")){
            GrayLevel[1].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Gray Level 1")){
            GrayLevel[2].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Gray Level 2")){
            GrayLevel[3].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Gray Level 3")){
            GrayLevel[4].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Gray Level 4")){
            GrayLevel[5].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Gray Level 5")){
            GrayLevel[6].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Gray Level 6")){
            GrayLevel[7].SetActive(false);
        }

        if(PlayerPrefs.HasKey("Yellow Level 4") && PlayerPrefs.HasKey("Red Level 13")){
            OrangeLevel[1].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Orange Level 1")){
            OrangeLevel[2].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Orange Level 2")){
            OrangeLevel[3].SetActive(false);
        }
        if(PlayerPrefs.HasKey("Orange Level 3")){
            OrangeLevel[4].SetActive(false);
        }

        if(PlayerPrefs.HasKey("Level 19") && PlayerPrefs.HasKey("Orange Level 4") && PlayerPrefs.HasKey("Gray Level 7")){
            InfiniteLevel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCleanDataAssure(){
        CleanDataAssure.SetActive(true);
    }
    public void OnClickCleanData(){
        PlayerPrefs.DeleteAll();
        //畫質設定
        SceneManager.LoadScene("Waiting In Game");
    }
    public void OnClickCancelCleanData(){
        CleanDataAssure.SetActive(false);
    }
}
