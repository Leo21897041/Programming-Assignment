using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float progress;
    public float duration;
    public float minDuration;
    public float maxDuration;

    public GameObject asteroidPrefab;
    public string movementType;
    public string spawnerPosition;
    public float padding;

    private void Start()
    {
        ChangeTimerDuration();
        ChangeSpawnerPosition();
    }
    private void Update()
    {
        progress += Time.deltaTime;

        if (progress >= duration)
        {
            GameObject asteroidObj = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            asteroidObj.GetComponent<AsteroidMovement>().movementType = movementType;

            ChangeTimerDuration();
            ChangeSpawnerPosition();
            progress = 0f;
        }
    }

    private void ChangeTimerDuration()
    {
        duration = Random.Range(minDuration, maxDuration);
    }

    private void ChangeSpawnerPosition()
    {
        switch (spawnerPosition)
        {
            case "Top": transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height + padding, 0)); break;
            case "Bottom": transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0 - padding, 0)); break;
            case "Left": transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0 - padding, Random.Range(0, Screen.height), 0)); break;
            case "Right": transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + padding, Random.Range(0, Screen.height), 0)); break;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}

