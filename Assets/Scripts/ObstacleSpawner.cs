using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float spawnInterval = 1f;
    public float xRange = 7f;

    public float minFallSpeed = 3f;
    public float maxFallSpeed = 8f;

    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    private float timer;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver())
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        float randomSize = Random.Range(minSize, maxSize);
        newObstacle.transform.localScale = new Vector3(randomSize, randomSize, 1f);

        float randomSpeed = Random.Range(minFallSpeed, maxFallSpeed);

        Obstacle obstacleScript = newObstacle.GetComponent<Obstacle>();
        obstacleScript.SetFallSpeed(randomSpeed);
    }
}