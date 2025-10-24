using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public int bestScore = 0;
    public Text scoreText;
    public Text bestScoreText;
    public GameObject gameOverScreen;
    public GameObject gameSound;
    public GameObject gameOverSound;
    private bool hasGameEnded = false;

    [ContextMenu("Increase Score")]

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best " + bestScore.ToString();
    }

    public void addScore( int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score " + playerScore.ToString();

        if (playerScore > bestScore)
        {
            bestScoreText.text = "Best " + playerScore.ToString();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void gameOver()
    {

        if (!hasGameEnded)
        {
            gameOverScreen.SetActive(true);
            gameSound.SetActive(false);
            gameOverSound.GetComponent<AudioSource>().Play();
            hasGameEnded = true;

            if (playerScore > bestScore)
            {
                bestScore = playerScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
                PlayerPrefs.Save();
            }
        }
    }
}
