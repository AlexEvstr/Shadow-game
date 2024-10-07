using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(RectTransform))]
public class ColliderResizer : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RectTransform rectTransform;

    private void Awake()
    {
        // Получаем ссылки на компоненты
        boxCollider = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Подстраиваем размеры BoxCollider2D под размеры RectTransform
        boxCollider.size = rectTransform.rect.size;
    }
}
