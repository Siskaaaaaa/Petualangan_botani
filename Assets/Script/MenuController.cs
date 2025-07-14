using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Assign Canvas MenuLevelsPanel disini")]
    public GameObject menuLevelsPanel;

    // Dipanggil dari Button "Menu"
    public void ToggleMenuLevels()
    {
        if (menuLevelsPanel != null)
        {
            menuLevelsPanel.SetActive(!menuLevelsPanel.activeSelf);
        }
    }

    // Dipanggil dari Button "Keluar"
    public void KeluarAplikasi()
    {
        Application.Quit(); // Keluar dari aplikasi saat build
        Debug.Log("Aplikasi keluar."); // Untuk debugging di Editor
    }

    // Dipanggil dari Button "X (Close)" di dalam panel level
    public void TutupPanelLevel()
    {
        if (menuLevelsPanel != null)
        {
            menuLevelsPanel.SetActive(false);
        }
    }
}
