
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject HowToPlayPanel;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(2);
    }

    public void SaveLoad()
    {
        ES3AutoSaveMgr.Current.Load();
    }

    public void HowToPlay()
    {
        HowToPlayPanel.SetActive(true);

    }
    public void CloseHowtoplay_()
    {
        HowToPlayPanel.SetActive(false);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
