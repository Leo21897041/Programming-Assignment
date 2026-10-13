using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooter playerShooter;
    public PlayerPowerUp playerPowerUp;

    public int numberOfAsteroidsDestroyed;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
        playerPowerUp = GetComponent<PlayerPowerUp>();
    }
    private void Update()
    {
        if (numberOfAsteroidsDestroyed >= 2)
        {
            playerShooter.numberOfMissiles = 2;
        }
        if (numberOfAsteroidsDestroyed >= 4)
        {
            playerShooter.numberOfMissiles = 3;
        }
        if (numberOfAsteroidsDestroyed >= 6)
        {
            playerShooter.numberOfMissiles = 4;
        }
        if (numberOfAsteroidsDestroyed >= 8)
        {
            playerShooter.numberOfMissiles = 5;
        }
    }
    public void ActivatePowerUp()
    {
        playerPowerUp.SpawnShields();
    }
}
