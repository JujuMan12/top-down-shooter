using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private UIController uiController;

    public void ResumeGame()
    {
        uiController.ChangePauseMenuState(false);
    }

    public void RestartGame()
    {
        uiController.ResetScore();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
