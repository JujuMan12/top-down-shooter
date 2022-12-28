using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    [HideInInspector] private static int playerScore;
    [HideInInspector] private static int aiScore;

    [Header("UI")]
    [SerializeField] private TMPro.TextMeshProUGUI playerScoreUI;
    [SerializeField] private TMPro.TextMeshProUGUI aiScoreUI;

    private void Start()
    {
        playerScoreUI.text = playerScore.ToString();
        aiScoreUI.text = aiScore.ToString();
    }

    public void AddScore(bool isPlayer)
    {
        if (isPlayer)
        {
            playerScore++;
            //playerScoreUI.text = playerScore.ToString();
        }
        else
        {
            aiScore++;
            //aiScoreUI.text = aiScore.ToString();
        }

        SceneManager.LoadScene(0);
    }

    public void ResetScore()
    {
        playerScore = 0;
        aiScore = 0;
    }
}
