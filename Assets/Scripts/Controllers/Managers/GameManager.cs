using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;

    private void Start()
    {
        FindFirstObjectByType<PlayerManager>();
    }
    public void GameOver()
    {

    }
}
