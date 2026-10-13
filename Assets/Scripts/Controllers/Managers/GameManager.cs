using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject[] enemySpawners;
    public AsteroidSpawnerManager asteroidSpawnerManager;

    private void Start()
    {
        FindFirstObjectByType<PlayerManager>();
    }
    private void Update()
    {
        if (playerManager == null)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        EnemyGameOver();
        AsteroidGameOver();
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
}
