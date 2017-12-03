using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject enemyPrefab;

    private GameObject currentObstacle;
    private GameObject currentEnemy;

    private Vector2 obstacleRange = new Vector2(2.7f, -2.3f);
    private Vector2 enemyRange = new Vector2(4f, -4f);

    private float lastEnemyPosition;

    void Start()
    {        
        currentObstacle = GameObject.Instantiate(obstaclePrefab);

        currentEnemy = GameObject.Instantiate(enemyPrefab);
    }
    
    void Update()
    {
       
        if (currentObstacle.transform.position.x <= -12)
        {
            float obstaclePositionY = Random.Range(obstacleRange.y, obstacleRange.x);
            currentObstacle.transform.position = new Vector3(10, obstaclePositionY, 0);
            
            if (!currentEnemy)
            {
                float enemyPositionY = Random.Range(enemyRange.y, enemyRange.x);
                currentEnemy = GameObject.Instantiate(enemyPrefab, new Vector3(currentObstacle.transform.position.x + 10, enemyPositionY, 0), enemyPrefab.transform.rotation);
            }
        }
        else if (!currentEnemy && currentObstacle.transform.position.x > lastEnemyPosition)
        {
            float enemyPositionY = Random.Range(enemyRange.y, enemyRange.x);
            currentEnemy = GameObject.Instantiate(enemyPrefab, new Vector3(currentObstacle.transform.position.x + 10, enemyPositionY, 0), enemyPrefab.transform.rotation);
        }


        if (currentEnemy)
            lastEnemyPosition = currentEnemy.transform.position.x;

        if (currentEnemy && currentEnemy.transform.position.x <= -12)
        {
            float enemyPositionY = Random.Range(enemyRange.y, enemyRange.x);
            currentEnemy.transform.position = new Vector3(currentObstacle.transform.position.x + 10, enemyPositionY, 0);
        }
    }
}
