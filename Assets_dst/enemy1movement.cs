using UnityEngine;

public class enemy1movement : MonoBehaviour
{
    public float speed = 5f; // Hareket hızı

    void Update()
    {
        // Düşmanı yukarıdan aşağıya doğru hareket ettirir.
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Eğer düşman ekranın altına düşerse, yok edilir.
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
