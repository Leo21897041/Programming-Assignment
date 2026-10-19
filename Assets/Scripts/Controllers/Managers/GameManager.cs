using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject[] enemySpawners;
    public AsteroidSpawnerManager asteroidSpawnerManager;
    public UIManager uIManager;
    public bool isGameOver;

    private void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        isGameOver = false;
    }
    private void Update()
    {
        if (playerManager == null && isGameOver == false)
        {
            GameOver();
            isGameOver = true;
        }
    }
    public void GameOver()
    {
        EnemyGameOver();
        AsteroidGameOver();

        Invoke("DisplayStatsPanel", 1f);
    }
    private void EnemyGameOver()
    {
        enemySpawners[0].GetComponent<EnemySpawner>().isGameOver = true;
        enemySpawners[1].GetComponent<EnemySpawner>().isGameOver = true;
        
        if (enemySpawners[0].GetComponent<EnemySpawner>().enemySpawned != null)
        {
            enemySpawners[0].GetComponent<EnemySpawner>().enemySpawned.GetComponent<EnemyManager>().isGameOver = true;
        }
        if (enemySpawners[1].GetComponent<EnemySpawner>().enemySpawned != null)
        {
            enemySpawners[1].GetComponent<EnemySpawner>().enemySpawned.GetComponent<EnemyManager>().isGameOver = true;
        }
    }
    private void AsteroidGameOver()
    {
        asteroidSpawnerManager.GameOver();
    }
    private void DisplayStatsPanel()
    {        
        uIManager.DisplayStatsPanel();
    }
}
