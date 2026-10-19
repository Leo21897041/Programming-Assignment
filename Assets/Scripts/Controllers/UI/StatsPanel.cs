using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsPanel : MonoBehaviour
{
    public float delay = 0.5f;
    public TextMeshProUGUI enemiesText;
    public TextMeshProUGUI asteroidText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScoreText;
    public GameObject retryButton;

    Coroutine displayStatsCoroutine;
    private void Start()
    {
        enemiesText.enabled = false;
        asteroidText.enabled = false;
        highScoreText.enabled = false;
        finalScoreText.enabled = false;

        retryButton.SetActive(false);
    }
    public void DisplayStats(int numberOfEnemies, int numberOfAsteroids, int highScore, int finalScore)
    {
        if (displayStatsCoroutine == null)
        {
            gameObject.SetActive(true);
            displayStatsCoroutine = StartCoroutine(DisplayStatsUpdate(numberOfEnemies, numberOfAsteroids, highScore, finalScore));
        }
    }

    public IEnumerator DisplayStatsUpdate(int numberOfEnemies, int numberOfAsteroids, int highScore, int finalScore)
    {
        yield return new WaitForSeconds(delay);

        enemiesText.text = "Enemies: " + numberOfEnemies;
        enemiesText.enabled = true;
        yield return new WaitForSeconds(delay);

        asteroidText.text = "Asteroids: " + numberOfAsteroids;
        asteroidText.enabled = true;
        yield return new WaitForSeconds(delay);

        finalScoreText.text = "Final Score: " + finalScore;
        finalScoreText.enabled = true;
        yield return new WaitForSeconds(delay);

        highScoreText.text = "High Score: " + highScore;
        highScoreText.enabled = true;
        yield return new WaitForSeconds(delay);

        retryButton.SetActive(true);
    }
    public void RestartButton()
    {
        FindFirstObjectByType<LevelManager>().ResetStats();

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
