using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUiController : MonoBehaviour
{
    [SerializeField] private Button _backBtn;

    private void Start()
    {
        _backBtn.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        StartCoroutine(ClickWaitAndMake());
    }

    private IEnumerator ClickWaitAndMake()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("MainMenu");
    }
}
