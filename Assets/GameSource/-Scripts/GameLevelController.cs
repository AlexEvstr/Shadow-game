using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelController : MonoBehaviour
{
    [SerializeField] private Button[] _levels;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject[] _gamePanels;
    [SerializeField] private GameObject[] _gameElements;
    [SerializeField] private GameObject _sectionCompleted;
    private AudioManager _audioManager;
    private int _currentLevelIndex;
    private int _bestLevel;

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        foreach (var element in _gameElements)
        {
            element.SetActive(false);
        }
        _levelsPanel.SetActive(true);

        foreach (var item in _gamePanels)
        {
            item.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "BuildingsGame")
            _bestLevel = PlayerPrefs.GetInt("HighestLevelBuilding", 1);
        else _bestLevel = PlayerPrefs.GetInt("HighestLevelPlanes", 1);

        foreach (var button in _levels)
        {
            button.onClick.AddListener(() => StartGame(button));

            if (_bestLevel < int.Parse(button.name))
            {
                button.interactable = false;
            }
        }
    }

    public void PlayClickSound()
    {
        _audioManager.PlayClickSound();
    }

    private void StartGame(Button button)
    {
        foreach (var element in _gameElements)
        {
            element.SetActive(true);
        }
        _levelsPanel.SetActive(false);
        _currentLevelIndex = int.Parse(button.name) - 1;
        _gamePanels[_currentLevelIndex].SetActive(true);

        if (SceneManager.GetActiveScene().name == "BuildingsGame")
            PlayerPrefs.SetInt("CurrentLevelIndexBuilding", _currentLevelIndex);
        else PlayerPrefs.SetInt("CurrentLevelIndexPlanes", _currentLevelIndex);
    }

    public void CloseCurrentLevel()
    {
        _gamePanels[_currentLevelIndex].SetActive(false);
    }

    public void ReloadLevel()
    {
        _gamePanels[_currentLevelIndex].SetActive(true);
    }

    public void ShowNextLevel()
    {
        _currentLevelIndex++;
        if (_currentLevelIndex >= 9)
        {
            _sectionCompleted.SetActive(true);
            return;
        }

        if (SceneManager.GetActiveScene().name == "BuildingsGame")
        {
            PlayerPrefs.SetInt("CurrentLevelIndexBuilding", _currentLevelIndex);
            _bestLevel = PlayerPrefs.GetInt("HighestLevelBuilding", 1);
        }

        else
        {
            PlayerPrefs.SetInt("CurrentLevelIndexPlanes", _currentLevelIndex);
            _bestLevel = PlayerPrefs.GetInt("HighestLevelPlanes", 1);
        }

        
        if (_currentLevelIndex >= _bestLevel)
        {
            _bestLevel++;
            if (SceneManager.GetActiveScene().name == "BuildingsGame")
                PlayerPrefs.SetInt("HighestLevelBuilding", _bestLevel);
            else PlayerPrefs.SetInt("HighestLevelPlanes", _bestLevel);
        }
        _gamePanels[_currentLevelIndex].SetActive(true);
    }
}