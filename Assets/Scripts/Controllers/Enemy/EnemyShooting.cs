using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShooting : MonoBehaviour
{
    public GameObject missilePrefab;

    public EnemyManager enemyManager;
    public float duration;
    public float progress;
    public float minFireRate;
    public float maxFireRate; 
    private void Start()
    {
        enemyManager = GetComponent<EnemyManager>();

        ChangeFireRate();
    }
    void Update()
    {
        if (enemyManager.isGameOver) return;

        else
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
