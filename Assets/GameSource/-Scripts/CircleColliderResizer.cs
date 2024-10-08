using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(RectTransform))]
public class CircleColliderResizer : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private RectTransform rectTransform;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        float radius = Mathf.Min(rectTransform.rect.width, rectTransform.rect.height) / 2f;
        circleCollider.radius = radius;
    }
}