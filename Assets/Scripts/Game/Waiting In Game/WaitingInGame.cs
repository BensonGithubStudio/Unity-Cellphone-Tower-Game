using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingInGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeToAwakeScene", 5);
    }

    void ChangeToAwakeScene(){
        SceneManager.LoadScene("Awake Game");
    }
}
