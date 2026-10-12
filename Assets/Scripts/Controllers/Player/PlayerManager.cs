using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerShooter playerShooter;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 directionalInput = context.ReadValue<Vector2>();

        if (directionalInput == Vector2.zero)
        {
            playerMovement.direction = Vector3.zero;
        }
        else
        {
            playerMovement.direction = new Vector3(Mathf.Sign(directionalInput.x), Mathf.Sign(directionalInput.y), 0);
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerShooter.SpawnMissile();
        }
    }
}
