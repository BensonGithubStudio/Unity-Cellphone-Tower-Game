using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicControl : MonoBehaviour
{
    public AudioSource AwakeGameSceneBackground;
    public AudioSource LevelChooseSceneBackground;

    public bool IsInAwakeScene;
    public float AwakeGameSceneBackgroundVolume;
    public float AddSpeed1;
    public bool IsInLevelChooseScene;
    public float LevelChooseSceneBackgroundVolume;
    public float AddSpeed2;

    // Start is called before the first frame update
    void Start()
    {
        IsInAwakeScene = false;
        IsInLevelChooseScene = false;

        if(AwakeGameSceneBackground == null){
            IsInLevelChooseScene = true;
        }
        if(LevelChooseSceneBackground == null){
            IsInAwakeScene = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsInAwakeScene){
            if(AwakeGameSceneBackgroundVolume < 1){
                AwakeGameSceneBackgroundVolume += AddSpeed1 * Time.deltaTime;
                AwakeGameSceneBackground.volume = AwakeGameSceneBackgroundVolume;
            }
        }

        if(IsInLevelChooseScene){
            if(LevelChooseSceneBackgroundVolume < 1){
                LevelChooseSceneBackgroundVolume += AddSpeed2 * Time.deltaTime;
                LevelChooseSceneBackground.volume = LevelChooseSceneBackgroundVolume;
            }
        }
    }
}
