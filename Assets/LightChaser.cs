using UnityEngine;
using UnityEngine.SceneManagement; // Örneğin, sahneyi yeniden yüklemek için

public class LightChaser : MonoBehaviour
{
    [Header("Takip Ayarları")]
    [Tooltip("Takip edilecek karakterin Transform'u (örneğin, kız karakter)")]
    public Transform chaseTarget;

    [Tooltip("Normal takip hızı")]
    public float baseChaseSpeed = 0.5f;

    [Tooltip("Karakter hareketsiz kaldığında artan takip hızı")]
    public float acceleratedChaseSpeed = 0.75f;

    [Tooltip("Hareketsizlik eşiği (saniye)")]
    public float idleThreshold = 2f;

    private Vector3 lastTargetPosition;
    private float idleTimer = 0f;

    void Start()
    {
        if (chaseTarget != null)
            lastTargetPosition = chaseTarget.position;
    }

    void Update()
    {
        if (chaseTarget == null)
            return;

        // Hedefin hareket edip etmediğini kontrol et
        if (Vector3.Distance(chaseTarget.position, lastTargetPosition) < 0.01f) {
            idleTimer += Time.deltaTime;
        } else {
            idleTimer = 0f;
            lastTargetPosition = chaseTarget.position;
        }

        // Hareketsizlik süresine göre hız belirle
        float currentSpeed = (idleTimer >= idleThreshold) ? acceleratedChaseSpeed : baseChaseSpeed;
        Vector3 dir = new Vector3(1,0,0);
        transform.parent.transform.position = Vector3.MoveTowards(transform.position, new Vector3(chaseTarget.position.x,3.71f,0), currentSpeed * Time.deltaTime);
        
        // Debug mesajı ekle
        Debug.Log($"Takip edilen pozisyon: {chaseTarget.position}, Şuanki Hız: {currentSpeed}, Işık Pozisyonu: {transform.position}");
    }

    // Çarpışma olduğunda (örneğin trigger ile) ölüm tetikleme
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == chaseTarget)
        {
            Debug.Log("Karakter ışık tarafından yakalandı!");
            // Örneğin, karakterin Die() metodunu çağırın veya sahneyi yeniden yükleyin
            // chaseTarget.GetComponent<PlayerController>()?.Die();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
