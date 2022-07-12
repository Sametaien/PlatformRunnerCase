#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class GameManager : MonoBehaviour
{
    public GameObject waitPanel;
    private void Awake()
    {
#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, false);
        Screen.fullScreen = false;
#endif
        Time.timeScale = 0;
        waitPanel.SetActive(true);
    }
    
    private void Update()
    {
#if UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            waitPanel.SetActive(false);
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            waitPanel.SetActive(false);
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Time.timeScale = 1;
            waitPanel.SetActive(false);
        }

#endif
    }
    


    public void LoadGame()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}