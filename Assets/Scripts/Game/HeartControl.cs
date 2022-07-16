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

    // Start is called before the first frame update
    void Start()
    {
        GameOverHint.SetActive(false);
        CanCallAppearHint = true;
    }

    // Update is called once per frame
    void Update()
    {
        NowHaveHeartText.text = "" + Heart;

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
