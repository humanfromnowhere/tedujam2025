using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float moveSpeed = 2f; // Engel hareket hızı
    public Transform leftPoint; // Sol limit
    public Transform rightPoint; // Sağ limit
    private bool movingRight = true; // Hareket yönü kontrolü

    private void Update()
    {
        // Engel hareketinin kontrolü
        if (movingRight)
        {
            if (transform.position.x <= rightPoint.position.x)  // Eşitlik koşulunu dahil et
            {
                // Sağa doğru hareket
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                // Yön değiştir
                movingRight = false;
            }
        }
        else
        {
            if (transform.position.x >= leftPoint.position.x)  // Eşitlik koşulunu dahil et
            {
                // Sola doğru hareket
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                // Yön değiştir
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncu engelle çarpıştığında oyuncuyu "öldür"
            Debug.Log("Player has died!");
            Destroy(collision.gameObject); // Oyuncu objesini yok et
        }
    }
}
