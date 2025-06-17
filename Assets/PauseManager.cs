using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu; // Assign panel PauseMenu dari Canvas

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void GoToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // ganti sesuai nama scene
    }

    public void GoToLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2"); // ganti sesuai nama scene
    }
}
