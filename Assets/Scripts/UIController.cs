using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [HideInInspector] public bool pauseMenuIsShown;

    [Header("Score")]
    [SerializeField] private GameScore gameScore;

    [Header("UI Elements")]
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePauseMenuState(!pauseMenuIsShown);
        }
    }

    public void ChangePauseMenuState(bool state)
    {
        pauseMenuIsShown = state;
        pauseMenu.SetActive(state);

        if (state)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ResetScore()
    {
        gameScore.ResetScore();
    }
}
