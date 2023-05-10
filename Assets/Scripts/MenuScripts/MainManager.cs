using UnityEngine;

using UnityEngine.SceneManagement;



public class MainManager : MonoBehaviour
{
    public static MainManager Instance   
    {
        get
        {
            if ( instance == null )
            {
                instance = FindObjectOfType<MainManager> ( );
                if ( instance == null )
                {
                    var instanceContainer = new GameObject ( "UiController" );
                    instance = instanceContainer.AddComponent<MainManager> ( );
                }
            }
            return instance;
        }
    }
    private static MainManager instance;
    [SerializeField]private GameObject pause;
    [SerializeField]private GameObject backMenu;
    //[SerializeField] private GameObject image;

    public bool isPause;

 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                 Pause();   
            }
        }
    }


    private void Pause()
    {
        
            pause.SetActive(true);
            Time.timeScale = 0f;
            backMenu.SetActive(true);
            //image.SetActive(true);
            isPause = true;

    }

    

    private void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        backMenu.SetActive(false);
        //image.SetActive(false);
        isPause = false;

        
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }




}
