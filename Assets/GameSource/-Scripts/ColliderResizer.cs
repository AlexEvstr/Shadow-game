using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(RectTransform))]
public class ColliderResizer : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RectTransform rectTransform;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        boxCollider.size = rectTransform.rect.size;
    }
}