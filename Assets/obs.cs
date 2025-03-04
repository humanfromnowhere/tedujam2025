using UnityEngine;

public class obs : MonoBehaviour
{
    public float speed; // Objeyi hareket ettirmek için kullanılacak hız
    private Vector3 targetPos; // Hedef pozisyon
    public GameObject ways; // Waypoint'leri tutan GameObject
    public Transform[] wayPoints; // Waypoint'lerin Transform'ları
    private int pointIndex; // Geçerli waypoint indexi
    private int pointCount; // Toplam waypoint sayısı
    private int direction = 1; // Hareket yönü

    private void Awake()
    {
        // Waypoints array'ini initialize et
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i);
        }
    }

    private void Start()
    {
        // Başlangıç değerlerini set et
        pointCount = wayPoints.Length;
        pointIndex = 0; // Daha mantıklı başlangıç için 0 indexinden başla
        targetPos = wayPoints[pointIndex].position;
    }

    private void Update()
    {
        // Her frame'de objeyi hedefe doğru hareket ettir
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        // Eğer hedefe ulaşıldıysa, bir sonraki hedefi belirle
        if (Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        // Eğer son waypoint'e ulaşıldıysa yönü tersine çevir
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }
        else if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;

        // Yeni hedef waypoint'i belirle
        targetPos = wayPoints[pointIndex].position;
    }
}
