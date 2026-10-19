using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int numberOfAsteroidsShot;
    public int numberOfEnemiesShot;
    public int shotsFired;
    public int score;
    public int highScore;
    private void Awake()
    {
        int numberOfLevelManagers = FindObjectsByType<LevelManager>(FindObjectsSortMode.None).Length;

        if (numberOfLevelManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
    public void ResetStats()
    {
        numberOfAsteroidsShot = 0;
        numberOfEnemiesShot = 0;
        score = 0;
    }
}
