
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(2);
    }

    public void SaveLoad()
    {
        ES3AutoSaveMgr.Current.Load();
    }
}
