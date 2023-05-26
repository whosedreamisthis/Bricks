using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    int score = 0;
    int lives = 3;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject gameOverPanel;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        gameOverPanel.SetActive(false);
    }
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
    }

    public void UpdateScore(int changeInScore)
    {
        score += changeInScore;
        scoreText.text = "Score: " + score.ToString();
    }


    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
