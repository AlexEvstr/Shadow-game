using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiController : MonoBehaviour
{
    [SerializeField] private Button _backBtn;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    private AudioManager _audioManager;


    private void Start()
    {
        _backBtn.onClick.AddListener(BackToMenu);
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void BackToMenu()
    {
        StartCoroutine(ClickWaitAndMake());
        _audioManager.PlayClickSound();
    }

    private IEnumerator ClickWaitAndMake()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowWinPanel()
    {
        StartCoroutine(WinBehavior());
    }

    private IEnumerator WinBehavior()
    {
        _winPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _audioManager.PlayWinSound();
        yield return new WaitForSeconds(3.0f);
        if (_winPanel != null)
        {
            CloseWinPanel();
        }
    }

    public void ShowLosePanel()
    {
        StartCoroutine(LoseBehavior());
    }

    private IEnumerator LoseBehavior()
    {
        _losePanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _audioManager.PlayLoseSound();
        yield return new WaitForSeconds(3.0f);
        if (_winPanel != null)
        {
            CloseLosePanel();
        }
    }

    public void CloseWinPanel()
    {
        _winPanel.SetActive(false);
        _audioManager.PlayClickSound();
    }

    public void CloseLosePanel()
    {
        _losePanel.SetActive(false);
        _audioManager.PlayClickSound();
    }
}