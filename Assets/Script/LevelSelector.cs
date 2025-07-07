using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1"); // Pastikan scene ini sudah di Build Settings
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("level3");
    }
}
