using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PolygonCollider2D), typeof(Image))]
public class PolygonColliderResizer : MonoBehaviour
{
    private void Start()
    {
        Image image = GetComponent<Image>();

        if (image.sprite != null)
        {
            Sprite sprite = image.sprite;

            PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();

            polygonCollider.pathCount = sprite.GetPhysicsShapeCount();

            RectTransform rectTransform = GetComponent<RectTransform>();
            Vector2 sizeDelta = rectTransform.rect.size;

            List<Vector2> path = new List<Vector2>();

            for (int i = 0; i < polygonCollider.pathCount; i++)
            {
                path.Clear();
                sprite.GetPhysicsShape(i, path);

                for (int j = 0; j < path.Count; j++)
                {
                    Vector2 point = path[j];

                    point.x = (point.x / sprite.bounds.size.x) * sizeDelta.x;
                    point.y = (point.y / sprite.bounds.size.y) * sizeDelta.y;

                    Vector3 worldPoint = rectTransform.TransformPoint(new Vector3(point.x, point.y, 0));
                    Vector3 localPoint = transform.InverseTransformPoint(worldPoint);

                    path[j] = new Vector2(localPoint.x, localPoint.y);
                }

                polygonCollider.SetPath(i, path.ToArray());
            }
        }
    }
}