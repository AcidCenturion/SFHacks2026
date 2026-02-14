using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Controls()
    {
        controlsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void CloseControlsPanel()
    {
        controlsPanel.SetActive(false);
    }
}
