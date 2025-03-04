using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    public Transform head;
    public float minBound = -3f;
    public float maxBound = -3.75f;
    private Tween headLoopTween;

    void Start()
    {
        // Set the starting position to minBound
        head.position = new Vector3(head.position.x, minBound, head.position.z);
        HeadLoopAnimation();
    }

    void HeadLoopAnimation()
    {
        // Create a target position using the current x and z values, but with maxBound as the y value
        Vector3 targetPosition = new Vector3(head.position.x, maxBound, head.position.z);
        
        // Tween the transform directly using DOMove
        headLoopTween = head.DOMove(targetPosition, 2.5f)
                           .SetEase(Ease.Linear)
                           .SetLoops(-1, LoopType.Yoyo);
    }
}
