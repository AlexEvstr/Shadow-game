using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(RectTransform))]
public class BallController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.anchoredPosition = new Vector2(0, 800);
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void LaunchBall()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Win!");
        }
        else if (collision.gameObject.CompareTag("BottomBorder"))
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            _rectTransform.anchoredPosition = new Vector2(0, 800);
        }
    }
}
