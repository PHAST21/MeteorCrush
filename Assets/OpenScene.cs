using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void SceneOpen(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
    public void Open(GameObject a)
    {
        a.SetActive(true);
    }
    public void Close(GameObject a)
    {
        a.SetActive(false);
    }
}
