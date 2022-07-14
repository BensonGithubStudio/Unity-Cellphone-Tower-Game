using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleGemControl : MonoBehaviour
{
    public Color[] GemColor = new Color[20];
    public int NowColor;

    // Start is called before the first frame update
    void Start()
    {
        NowColor = 0;
        InvokeRepeating("ChangeColor", 0, 0.05f);
    }

    void ChangeColor(){
        if(NowColor <= 19){
            this.gameObject.GetComponent<Renderer>().material.color = GemColor[NowColor];
            NowColor++;
        }else{
            NowColor = 0;
            this.gameObject.GetComponent<Renderer>().material.color = GemColor[NowColor];
        }
    }
}
