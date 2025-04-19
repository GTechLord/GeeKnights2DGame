using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour{

    public GameObject settingsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
