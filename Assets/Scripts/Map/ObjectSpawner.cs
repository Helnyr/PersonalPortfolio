using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ObjectSpawner : NetworkBehaviour
{
    [Header("Balls")]
    [SerializeField] private int maxBalls;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnDelay;

    public GameObject ball;
    public List<GameObject> activeBalls = new List<GameObject>();

    public Transform[] ballSpawnPoints;
    public Transform ballParent;

    [Header("Powerups")]
    [SerializeField] private int maxPowerups;
    [SerializeField] private float spawnTimerPowerup;
    [SerializeField] private float spawnDelayPowerup;

    public GameObject [] powerups;
    public List<GameObject> activePowerups = new List<GameObject>();

    public Transform[] powerupSpawnPoints;
    public Transform powerupParent;

    void Start()
    {
        spawnTimer = spawnDelay;
        spawnTimerPowerup = spawnDelayPowerup;
    }

    void Update()
    {
        if (MatchManager.instance.startGame)
        {
            if (isServer)
            {
                if (spawnTimer <= 0f && activeBalls.Count <= maxBalls) SpawnBall();
                spawnTimer -= Time.deltaTime;

                if (spawnTimerPowerup <= 0f && activePowerups.Count <= maxPowerups) SpawnPowerup();
                spawnTimerPowerup -= Time.deltaTime;
            }
        }
    }

    void SpawnBall()
    {
        int random = Random.Range(0, ballSpawnPoints.Length);
        activeBalls.Add(Instantiate(ball, ballSpawnPoints[random].position, ballSpawnPoints[random].rotation, ballParent));
        NetworkServer.Spawn(activeBalls[activeBalls.Count - 1]);
        spawnTimer = spawnDelay;
    }

    void SpawnPowerup()
    {
        int randomPos = Random.Range(0, powerupSpawnPoints.Length);
        int randomObject = Random.Range(0, powerups.Length);
        activePowerups.Add(Instantiate(powerups[randomObject], powerupSpawnPoints[randomPos].position, Quaternion.identity, powerupParent));
        NetworkServer.Spawn(activePowerups[activePowerups.Count - 1]);
        spawnTimerPowerup = spawnDelayPowerup;
    }
}
