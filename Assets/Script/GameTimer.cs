using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;         // Waktu mundur
    public TextMeshProUGUI pointText;         // Teks poin akhir
    public TextMeshProUGUI hudPointText;      // Teks poin saat bermain
    public TextMeshProUGUI hasilText;         // MENANG / KALAH

    public GameObject gameOverPanel;          // Panel Game Over
    public GameObject tombolMainLagi;         // Tombol untuk lanjut level
    public GameObject tombolMenu;             // Tombol menu / main ulang

    private float timeRemaining;
    private bool isRunning = true;

    private int currentPoint = 0;             // Poin sekarang
    private int poinMinimal = 0;              // Target poin tiap level
    private bool pemainMenang = false;        // Status menang/kalah

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name.ToLower();

        // Atur waktu & target poin per level
        if (sceneName == "level1")
        {
            timeRemaining = 90f;
            poinMinimal = 15;
        }
        else if (sceneName == "level2")
        {
            timeRemaining = 75f;
            poinMinimal = 20;
        }
        else if (sceneName == "level3")
        {
            timeRemaining = 60f;
            poinMinimal = 25;
        }
        else
        {
            timeRemaining = 60f;
            poinMinimal = 10;
        }

        Debug.Log("Scene: " + sceneName + " | Waktu: " + timeRemaining + "s | Target: " + poinMinimal);

        currentPoint = 0;
        UpdatePointUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isRunning && timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0f)
                timeRemaining = 0f;

            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (timeRemaining <= 0f)
                TimerSelesai();
        }

        // Untuk testing (opsional)
        if (Input.GetKeyDown(KeyCode.P))
        {
            TambahPoint(5);
        }
    }

    void TimerSelesai()
    {
        isRunning = false;
        timerText.text = "00:00";

        if (pointText != null)
            pointText.text = "Poin: " + currentPoint;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (currentPoint >= poinMinimal)
            {
                pemainMenang = true;

                if (hasilText != null)
                    hasilText.text = "MENANG!";
                if (tombolMainLagi != null)
                    tombolMainLagi.SetActive(true);
            }
            else
            {
                pemainMenang = false;

                if (hasilText != null)
                    hasilText.text = "KALAH!";
                if (tombolMainLagi != null)
                    tombolMainLagi.SetActive(false);
                if (tombolMenu != null)
                    tombolMenu.GetComponentInChildren<TextMeshProUGUI>().text = "Main Ulang";
            }

            if (tombolMenu != null)
                tombolMenu.SetActive(true);
        }
    }

    public void TambahPoint(int jumlah)
    {
        currentPoint += jumlah;
        UpdatePointUI();
    }

    private void UpdatePointUI()
    {
        if (hudPointText != null)
            hudPointText.text = "Poin: " + currentPoint;
    }

    public void LoadNextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name.ToLower();

        if (currentScene == "level1")
            SceneManager.LoadScene("level2");
        else if (currentScene == "level2")
            SceneManager.LoadScene("level3");
        else
            SceneManager.LoadScene("mainmenu");

        Time.timeScale = 1f;
    }

    public void KembaliKeMenu()
    {
        if (!pemainMenang)
        {
            // KALAH = Ulangi level ini
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // MENANG = ke menu utama
            SceneManager.LoadScene("mainmenu");
        }

        Time.timeScale = 1f;
    }

    public void StopTimer() => isRunning = false;
    public void StartTimer() => isRunning = true;
}
