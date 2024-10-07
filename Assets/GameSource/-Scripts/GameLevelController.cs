using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelController : MonoBehaviour
{
    [SerializeField] private Button[] _levels;
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject[] _gamePanels;
    [SerializeField] private GameObject[] _gameElements;

    private void Start()
    {
        foreach (var element in _gameElements)
        {
            element.SetActive(false);
        }
        _levelsPanel.SetActive(true);

        foreach (var item in _gamePanels)
        {
            item.SetActive(false);
        }
        int BestLevel = PlayerPrefs.GetInt("HighestLevel", 1);
        foreach (var button in _levels)
        {
            button.onClick.AddListener(() => StartGame(button));
            if (BestLevel < int.Parse(button.name))
            {
                button.interactable = false;
            }
        }
    }

    private void StartGame(Button button)
    {
        foreach (var element in _gameElements)
        {
            element.SetActive(true);
        }
        _levelsPanel.SetActive(false);
        _gamePanels[int.Parse(button.name)-1].SetActive(true);
    }
}
