using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highscoreText;
    public int highScore;
    public GameObject gameOverScreen;
    public GameObject startGameScreen;
    public GameObject bird;
    public GameObject pipeSpawner;
    public GameObject cloudSpawner;

    public void startGame()
    {
        startGameScreen.SetActive(false);
        bird.SetActive(true);
        bird.GetComponent<Rigidbody2D>().simulated = true;
        pipeSpawner.SetActive(true);
        cloudSpawner.SetActive(true);
        scoreText.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(true);
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highscoreText.text = "high score:\n" + highScore.ToString();
    }

    public void updateScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
        highscoreText.text = "high score:\n" + highScore.ToString();
    }
}