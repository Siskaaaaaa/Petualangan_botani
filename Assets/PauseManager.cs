using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("Assign Panel dari Canvas (Pause > menupause > Panel)")]
    public GameObject pauseMenu;

    private bool isPaused = false;

    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        if (pauseMenu == null)
        {
            Debug.LogWarning("Pause Menu belum di-assign di inspector!");
            return;
        }

        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        if (pauseMenu != null) pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void GoToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu"); // Ganti dengan nama scene kamu
    }
}
