using UnityEngine;

using UnityEngine.SceneManagement;



public class MainManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject backMenu;
    public GameObject image;
    [SerializeField] private GameObject minimap;
    
    public bool isPause;



    void Start()
    {
       
    }

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
        MiniMap();
    }

    private void Pause()
    {
        
            pause.SetActive(true);
            Time.timeScale = 0f;
            backMenu.SetActive(true);
            image.SetActive(true);
            isPause = true;

    }
    void MiniMap()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            minimap.gameObject.SetActive(true);
        }
        else
        {
            minimap.gameObject.SetActive(false);
        }
    }

    private void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        backMenu.SetActive(false);
        image.SetActive(false);
        isPause = false;

        
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

   
   
   
    
}
