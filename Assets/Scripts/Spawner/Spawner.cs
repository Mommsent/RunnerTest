using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstaclePerent;

    public float obstacleSpawnTime = 2f;
    [Range(0f, 1f)] public float obstacleSpawnTimeFactor = 0.1f;
    public float obstacleSpeed = 1f;
    [Range(0f, 1f)] public float obstacleSpeedFactor = 0.2f;

    private float _obstacleSpawnTime;
    private float _obstacleSpeed;

    private float timeUntilObstacleSpawn;
    private float timeAlive;

    private void Start()
    {
        GameManager.Instance.GameEnded += ClearObstacles;
        GameManager.Instance.GameStarted += ResetFactors;
        timeAlive = 1f;
    }

    void Update()
    {
        if(GameManager.Instance.isPlaying)
        {
            timeAlive += Time.deltaTime;
            CalculateFactor();
            SpawnLoop();
        }
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if(timeUntilObstacleSpawn >= _obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0;
        }
    }

    private void ResetFactors()
    {
        timeAlive = 1f;
        _obstacleSpawnTime = obstacleSpawnTime;
        _obstacleSpeed = obstacleSpeed;
    }

    private void CalculateFactor()
    {
        _obstacleSpawnTime = obstacleSpawnTime / Mathf.Pow(timeAlive,obstacleSpawnTimeFactor);
        _obstacleSpeed = obstacleSpeed / Mathf.Pow(timeAlive, obstacleSpeedFactor);
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent = obstaclePerent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * _obstacleSpeed;
    }

    private void ClearObstacles()
    {
        foreach(Transform chiled in obstaclePerent)
        {
            Destroy(chiled.gameObject);
        }    
    }
}
