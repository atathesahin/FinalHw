
using UnityEngine;

using UnityEngine.SceneManagement;



public class MenuUIHandler : MonoBehaviour
{
    

    

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        
        Application.Quit();

    }
}
