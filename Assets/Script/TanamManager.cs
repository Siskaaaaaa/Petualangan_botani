using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TanamManager : MonoBehaviour
{
    public Tilemap tilemapTanaman;       // Tilemap khusus untuk tanaman
    public TileBase tileTanaman;         // Tile tanaman (misalnya pohon)
    public Transform player;             // Objek player

    public int poin = 0;                 // Skor
    public TMP_Text teksPoin;            // UI skor (TextMeshPro)

    // Fungsi saat tombol Tanam ditekan
    public void KlikTanam()
    {
        Vector3Int posisiGrid = tilemapTanaman.WorldToCell(player.position + Vector3.right);

        TileBase tileSekarang = tilemapTanaman.GetTile(posisiGrid);
        if (tileSekarang == tileTanaman)
        {
            Debug.Log("Sudah ada tanaman.");
            return;
        }

        tilemapTanaman.SetTile(posisiGrid, tileTanaman);
        Debug.Log("Tanam berhasil!");
    }

    // Fungsi saat tombol Tebang ditekan
    public void KlikTebang()
    {
        Vector3Int posisiGrid = tilemapTanaman.WorldToCell(player.position + Vector3.right);

        TileBase tileSaatIni = tilemapTanaman.GetTile(posisiGrid);
        if (tileSaatIni == tileTanaman)
        {
            tilemapTanaman.SetTile(posisiGrid, null);
            Debug.Log("Pohon ditebang!");

            poin += 1;
            teksPoin.text = "Poin: " + poin;
        }
        else
        {
            Debug.Log("Tidak ada pohon untuk ditebang.");
        }
    }
}
