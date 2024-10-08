using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(RectTransform))]
public class BallController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private RectTransform _rectTransform;
    private AudioManager _audioManager;
    [SerializeField] private GameUiController _gameUiController;
    [SerializeField] private GameLevelController _gameLevelController;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rectTransform = GetComponent<RectTransform>();
        _audioManager = FindObjectOfType<AudioManager>();
        _rectTransform.anchoredPosition = new Vector2(0, 800);
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public void LaunchBall()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _audioManager.PlayLaunchSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            _gameUiController.ShowWinPanel();
            _gameLevelController.CloseCurrentLevel();
            _gameLevelController.ShowNextLevel();
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            _rectTransform.anchoredPosition = new Vector2(0, 800);
            _audioManager.PlayBasketSound();
        }
        else if (collision.gameObject.CompareTag("BottomBorder"))
        {
            _gameUiController.ShowLosePanel();
            _gameLevelController.CloseCurrentLevel();
            _gameLevelController.ReloadLevel();
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            _rectTransform.anchoredPosition = new Vector2(0, 800);
            _audioManager.PlayLoseSound();
        }
        else
        {
            _audioManager.PlayCollisionSound();
        }
    }
}