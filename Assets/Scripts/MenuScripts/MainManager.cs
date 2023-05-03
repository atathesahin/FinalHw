using UnityEngine;

using UnityEngine.SceneManagement;



public class MainManager : MonoBehaviour
{
    //[SerializeField] private GameObject pause;
    //[SerializeField] private GameObject backMenu;
    [SerializeField] private GameObject image;

    public bool isPause;
    [SerializeField] private GameObject weaponUI;


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
        if (Input.GetKeyDown(KeyCode.C))
        {
            weaponUI.SetActive(!weaponUI.activeSelf);
        }
    }

    private void Pause()
    {
        
            //pause.SetActive(true);
            Time.timeScale = 0f;
            //backMenu.SetActive(true);
            image.SetActive(true);
            isPause = true;

    }


    private void Resume()
    {
        //pause.SetActive(false);
        Time.timeScale = 1f;
        //backMenu.SetActive(false);
        image.SetActive(false);
        isPause = false;

        
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }




}
