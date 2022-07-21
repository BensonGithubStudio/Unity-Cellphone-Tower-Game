using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartControl : MonoBehaviour
{
    public GameObject GameOverHint;
    public GameObject TowerPosition;
    public bool CanCallAppearHint;

    public Text NowHaveHeartText;

    public int Heart;
    public int SaveHeart;
    public bool CanSaveHeart;

    // Start is called before the first frame update
    void Start()
    {
        GameOverHint.SetActive(false);
        CanCallAppearHint = true;

        TowerPosition = GameObject.Find("Tower Position");
        CanSaveHeart = true;
    }

    // Update is called once per frame
    void Update()
    {
        NowHaveHeartText.text = "" + Heart;

        if(!this.gameObject.GetComponent<GameButton>().HeartInfinite){
            if(CanSaveHeart == false){
                Heart = SaveHeart;
                CanSaveHeart = true;
            }
        }

        if(this.gameObject.GetComponent<GameButton>().HeartInfinite){
            if(CanSaveHeart){
                SaveHeart = Heart;
                CanSaveHeart = false;
            }
            Heart = 2147483647;
        }

        if(Heart <= 0){
            Heart = 0;
            if(CanCallAppearHint){
                Invoke("AppearGameOver", 3);
                CanCallAppearHint = false;
            }
        }
    }

    void AppearGameOver (){
        GameOverHint.SetActive(true);
        TowerPosition.SetActive(false);
    }
}
