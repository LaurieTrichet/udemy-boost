using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameStateSO gameState = null;


    private void Awake()
    {
        gameState.IsTransitioning = false;
    }

    public void ReloadScene()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    internal void GoToNextScene()
    {
        int buildIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitGame(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Application.Quit();
        }
    }

}
