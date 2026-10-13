using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShooting : MonoBehaviour
{
    public GameObject missilePrefab;

    public float duration;
    public float progress;

    public float minFireRate;
    public float maxFireRate;

    public EnemyMovement enemyMovement;
    private void Start()
    {
        ChangeFireRate();

        enemyMovement = GetComponent<EnemyMovement>();
    }
    void Update()
    {
        if (enemyMovement.isPlayerSpotted)
        {
            progress += Time.deltaTime;

            if (progress >= duration)
            {
                SpawnMissile();

                ChangeFireRate();

                progress = 0f;
            }
        }
    }
    private void ChangeFireRate()
    {
        duration = Random.Range(minFireRate, maxFireRate);
    }
    public void SpawnMissile()
    {        
        GameObject missileObj = Instantiate(missilePrefab, transform.position, transform.rotation);
    }

}
