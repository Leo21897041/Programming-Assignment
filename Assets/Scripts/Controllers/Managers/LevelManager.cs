using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int numberOfAsteroidsShot;
    public int numberOfEnemiesShot;
    public int shotsFired;
    public int score;
    public int highScore;

    private void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
