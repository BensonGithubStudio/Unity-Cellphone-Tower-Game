using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject MousePositionImage;

    // Start is called before the first frame update
    void Start()
    {
        MousePositionImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            MousePositionImage.transform.position = Input.mousePosition;
            MousePositionImage.SetActive(false);
            MousePositionImage.SetActive(true);
        }
    }
}
