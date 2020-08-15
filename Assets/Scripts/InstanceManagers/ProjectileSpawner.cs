 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [Header("Minimal x for Spawn Position")]
    [SerializeField] private float minX;
    [Header("Maximal x for Spawn Position")]
    [SerializeField] private float maxX;
    [Header("Minimal y for Spawn Position")]
    [SerializeField] private float minY;
    [Header("Maximal y for Spawn Position")]
    [SerializeField] private float maxY;
    [Header("Average spawn rate in seconds")]
    [SerializeField] private float averageSpawnRate;
    [Header("Deviation from the spawn rate in parts of Average rate")]
    [SerializeField] private float deviationRate;
    [Header("Spawnable prefab")]
    [SerializeField] private GameObject spawnablePrefab;
    [Header("Don't shoot near the player")]
    [SerializeField] private float deltaRadius;
    private float spawnX;
    private float spawnY;
    private float transitionTime = 1f; 
    //Shoot direction
    //0 - up
    //1 - right
    //2 - down
    //3 - left 
    [SerializeField] private int direction;
    private float currentSpawnRate;
    private Vector3 playerPosition;
    private int previousScore;
    // Start is called before the first frame update
    private float CalculateSpawnRate()
    {
        //averageSpawnRate = 1/(1/averageSpawnRate + 0.1f * ObjectivePoint.score);
        return averageSpawnRate;
    }
    void Start()
    {
        previousScore = ObjectivePoint.score;
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        currentSpawnRate = transitionTime + averageSpawnRate + Random.Range(-deviationRate * averageSpawnRate, deviationRate * averageSpawnRate);
    }
    private void RandomizeSpawnPosition()
    {
        switch(direction)
        {

            case 0:
                spawnY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y- 0.5f;
                spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 0.3f, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 0.3f);
                break;
            case 1:
                spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 0.3f, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 0.3f);
                spawnX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x - 1f;
                break;
            case 2:
                spawnY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y + 0.5f;
                spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 0.3f, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - 0.3f);
                break;
            case 3:
                spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y + 0.3f, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - 0.3f);
                spawnX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x + 1f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(previousScore != ObjectivePoint.score)
        {
            previousScore = ObjectivePoint.score;
            CalculateSpawnRate();
        }
        currentSpawnRate -= Time.deltaTime;
        if(currentSpawnRate <= 0)
        {
            Vector3 spawnPosition;
            do
            {
                RandomizeSpawnPosition();
                spawnPosition = new Vector3(spawnX, spawnY, 0f);
            } while((playerPosition - spawnPosition).magnitude < deltaRadius);
            GameObject spawned = Instantiate(spawnablePrefab, spawnPosition, spawnablePrefab.transform.rotation);
            currentSpawnRate = averageSpawnRate + Random.Range(-deviationRate * averageSpawnRate, deviationRate * averageSpawnRate);
            if(ProjectileDeath.projectileCount >= 1 * (ObjectivePoint.score) + 3)
            {
                //ProjectileDeath.projectileCount--;
                Destroy(spawned);
            }
        } 
    }
}
