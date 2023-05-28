using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.anyKeyDown){
            Invoke("LoadScene",0.5f);

        }
    }
    
    void LoadScene()
    {
        Application.LoadLevel("MainMenu");
    }
}
