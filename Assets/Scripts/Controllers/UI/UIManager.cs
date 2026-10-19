using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject statsPanelPrefab;
    public void DisplayStatsPanel()
    {
        LevelManager levelManager = FindFirstObjectByType<LevelManager>();

        int numberOfAsteroidsShot = levelManager.numberOfAsteroidsShot;
        int numberOfEnemiesShot = levelManager.numberOfEnemiesShot;
        int highScore = levelManager.highScore;
        int finalScore = levelManager.score;

        GameObject statsPanelObj = Instantiate(statsPanelPrefab, transform.position, Quaternion.identity, transform);
        StatsPanel statsPanelObjScript = statsPanelObj.GetComponent<StatsPanel>();

        statsPanelObjScript.DisplayStats(numberOfEnemiesShot, numberOfAsteroidsShot, highScore, finalScore);

        print("worked");
    }
}
