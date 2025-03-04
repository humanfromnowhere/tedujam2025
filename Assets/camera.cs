using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform component'ine bir referans
    public float yOffset; // Kamera ile oyuncu arasındaki y ekseni ofseti
    public float zOffset; // Kamera ile oyuncu arasındaki z ekseni ofseti

    void Update()
    {
        // Kamera pozisyonunu güncelle
        transform.position = new Vector3(player.position.x, yOffset, zOffset);
    }
}
