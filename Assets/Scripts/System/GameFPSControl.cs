using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFPSControl : MonoBehaviour
{
    public int NowFPS;
    public Text FpsText;

    // Start is called before the first frame update
    void Start()
    {
        NowFPS = 0;
        InvokeRepeating("CoculateFPS", 0, 1);
    }

    void CoculateFPS(){
        FpsText.text = "FPS : " + NowFPS;
        NowFPS = 0;
    }

    // Update is called once per frame
    void Update()
    {
        NowFPS += 1;
    }
}
