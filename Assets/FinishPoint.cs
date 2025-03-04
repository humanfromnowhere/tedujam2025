using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 'Player' etiketine sahip bir obje bitiş noktasına ulaştığında
        if (other.CompareTag("Player"))
        {
            Debug.Log("Finish Point Reached!");
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        // Seviye tamamlandığında yapılacak işlemler
        Debug.Log("Level Completed!");
        // Burada oyunun tamamlandığını belirten bir UI güncellemesi veya başka bir işlem yapılabilir.
    }
}
