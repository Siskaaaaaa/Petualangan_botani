using UnityEngine;

public class ShowMisiPanel : MonoBehaviour
{
    public GameObject panelMisi;

    public void TampilkanMisi()
    {
        panelMisi.SetActive(true);   // buka panel
    }

    public void TutupMisi()
    {
        panelMisi.SetActive(false);  // tutup panel
    }
}
