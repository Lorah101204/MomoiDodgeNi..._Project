using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text scoreTextAfterDead;
    public GameObject gameOverScene;
    public string sceneName;
    public GameObject pauseMenu;
    public static bool isPaused;

    [ContextMenu("Increase Score")] 
    public void addScore() {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
        if (playerScore > 0 && playerScore <= 50) {
            scoreTextAfterDead.text = "Ew! You dodge only " + playerScore.ToString() + " nigas";
        }
        if (playerScore > 50 && playerScore <= 100) {
            scoreTextAfterDead.text = "Wow!! " + playerScore.ToString() + " nigas. Not bad!";
        }
        if (playerScore > 100) {
            scoreTextAfterDead.text = "Are u super racing? " + playerScore.ToString() + " nigas???";
        }
    }

    public void restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void gameOver() {
        gameOverScene.SetActive(true);
        Time.timeScale = 0f;
    }

    public void pauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                resumeGame();
            } else {
                pauseGame();
            }
        }
    }

}
