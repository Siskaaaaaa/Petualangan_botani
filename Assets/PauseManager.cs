using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}