using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameBackgrounds;
    [SerializeField] private GameObject _enterWindow;
    private int _currentBackground;

    private void Start()
    {
        _currentBackground = 0;
    }

    public void OpenBackgroundChose()
    {
        _enterWindow.SetActive(false);
        _gameBackgrounds[_currentBackground].SetActive(true);
    }

    public void ChooseNextBackground()
    {
        _gameBackgrounds[_currentBackground].SetActive(false);
        _currentBackground++;
        if (_currentBackground == 3) _currentBackground = 0;
        _gameBackgrounds[_currentBackground].SetActive(true);
    }

    public void ChoosePrevBackground()
    {
        _gameBackgrounds[_currentBackground].SetActive(false);
        _currentBackground--;
        if (_currentBackground == -1) _currentBackground = 2;
        _gameBackgrounds[_currentBackground].SetActive(true);
    }

    public void ChooseBuildingsGame()
    {
        SceneManager.LoadScene("BuildingsGame");
    }

    public void ChoosePlanesGame()
    {
        SceneManager.LoadScene("PlanesGame");
    }
}
