using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private GameObject endGamePanel;
    [SerializeField]
    private TMP_Text highcoreText;
    [SerializeField]
    private Button restartButton;
    
    private bool gameOver;
    private int score;
    private int highestScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver = false;

        try
        {
            highestScore = PlayerPrefs.GetInt("Highest Score");
        }
        catch (System.Exception)
        {
            highestScore = 0;
        }

        // configure the restart button
        restartButton.onClick.AddListener( RestartGame );
    }

    public void GameOver()
    {
        CheckHighestScore();
        score = 0;
        gameOver = true;
        RaisePanel();
    }

    public void IncrementScore()
    {
        if ( ! gameOver )
        {
            score++;
            UpdateScore();
        }
    }

    private void UpdateScore(){
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score;
        }
    }

    private void RaisePanel()
    {
        if ( endGamePanel != null )
        {
            endGamePanel.SetActive(true);

            highcoreText.text = "Highest Score:\n" + highestScore;
        }
    }
    
    private void CheckHighestScore()
    {
        if ( score > highestScore ){
            highestScore = score;
            PlayerPrefs.SetInt("Highest Score", highestScore);
        }
    }

    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
