using UnityEngine;

public class AsteroidSpawnerManager : MonoBehaviour
{
    public AsteroidSpawner[] asteroidSpawner;

    public void GameOver()
    {
        for (int i = 0; i < asteroidSpawner.Length; i++)
        {
            asteroidSpawner[i].isGameOver = true;

            for (int j = 0; j < asteroidSpawner[i].spawnedAsteroids.Count; j++)
            {
                asteroidSpawner[i].spawnedAsteroids[j].isGameOver = true;
            }
        }
    }
}
