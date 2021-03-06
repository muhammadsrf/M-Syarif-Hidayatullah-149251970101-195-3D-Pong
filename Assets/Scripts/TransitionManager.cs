using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public AIScriptableObject AIScript;

    public void PlayHumanGame()
    {
        AudioManager.instance.Ketuk();
        AIScript.playWithAI = false;
        Debug.Log("Created by M Syarif Hidayatullah - 149251970101-195");
        SceneManager.LoadScene("Game");
    }

    public void PlayAIGame()
    {
        AudioManager.instance.Ketuk();
        AIScript.playWithAI = true;
        Debug.Log("Created by M Syarif Hidayatullah - 149251970101-195");
        SceneManager.LoadScene("Game");
    }

    public void ReplayGame()
    {
        AudioManager.instance.Ketuk();
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void BackToMainMenu()
    {
        AudioManager.instance.Ketuk();
        SceneManager.LoadScene("Main Menu");
    }

    public void HowToPlay()
    {
        AudioManager.instance.Ketuk();
        SceneManager.LoadScene("How to Play");
    }

    public void ExitGame()
    {
        Debug.Log("Game Quit.");
        AudioManager.instance.Ketuk();
        Application.Quit();
    }

    public void PlayKetuk()
    {
        AudioManager.instance.Ketuk();
    }
}
