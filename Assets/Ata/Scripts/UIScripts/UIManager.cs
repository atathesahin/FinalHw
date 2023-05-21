
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Maps");
    }

    public void SaveLoad()
    {
        ES3AutoSaveMgr.Current.Load();
    }
}
