using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance // singlton     
    {
        get
        {
            if ( instance == null )
            {
                instance = FindObjectOfType<UIManager> ( );
                if ( instance == null )
                {
                    var instanceContainer = new GameObject ( "UiController" );
                    instance = instanceContainer.AddComponent<UIManager> ( );
                }
            }
            return instance;
        }
    }
    private static UIManager instance;
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Test");
    }
}
