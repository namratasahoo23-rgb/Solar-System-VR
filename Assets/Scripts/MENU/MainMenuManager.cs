using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menuCanvas;

    public void StartExploration()
    {
        SceneManager.LoadScene("StartExploration");
    }

    public void GuidedLearning()
    {
        SceneManager.LoadScene("GuidedLearning");
    }

    public void QuizMode()
    {
        Debug.Log("Quiz Mode Clicked");
    }

    public void Settings()
    {
        Debug.Log("Settings Clicked");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}