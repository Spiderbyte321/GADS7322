using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UIManager : MonoBehaviour
{
    
    [Header("Components")]
    [SerializeField] private ElementalDisplay[] playerDisplays;

    [SerializeField] private CanvasGroup pauseScreen;

    private Dictionary<Key, UIToggleable> togglesDictionary = new Dictionary<Key, UIToggleable>();
    private bool isPaused;
    

    private void OnEnable()
    {
        GameManager.OnAllElements += UpdateDisplays;
        PlayerController.OnGamePause += TogglePauseScreen;
    }

    private void OnDisable()
    {
        GameManager.OnAllElements -= UpdateDisplays;
        PlayerController.OnGamePause -= TogglePauseScreen;
    }

    private void UpdateDisplays(EElement[] elements)
    {
        foreach (ElementalDisplay display in playerDisplays)
        {
            display.greyOutChosenElements(elements);
        }
    }

    private void TogglePauseScreen()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 1;
            pauseScreen.alpha = 1;
            pauseScreen.interactable = true;
            pauseScreen.blocksRaycasts = true;
        }
        else
        {
            Time.timeScale = 0;
            pauseScreen.alpha = 0;
            pauseScreen.interactable = false;
            pauseScreen.blocksRaycasts = false;
        }
    }
    
}
