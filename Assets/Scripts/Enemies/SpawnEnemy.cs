using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject strongEnemyPrefab;
    [SerializeField] GameObject heavyEnemyPrefab;
    [SerializeField] Transform pathContainer;

    [SerializeField] float spawnInterval = 2f;
    private int numOfEnemiesAlive = 0;
    private int numOfEnemiesSpawned = 0;

    [SerializeField] int maxEnemies = 5;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        numOfEnemiesSpawned++;
        if (numOfEnemiesSpawned <= maxEnemies)
        {
              GameObject enemy;
            if(numOfEnemiesSpawned == maxEnemies)
            {
                enemy = Instantiate(heavyEnemyPrefab, pathContainer.GetChild(0).position, Quaternion.identity);
            }else if(numOfEnemiesSpawned % 10 != 0 )
            {
                 // Spawn the enemy at the first node
                enemy = Instantiate(enemyPrefab, pathContainer.GetChild(0).position, Quaternion.identity);
            }else
            {
                enemy = Instantiate(strongEnemyPrefab, pathContainer.GetChild(0).position, Quaternion.identity);
            }
           

            // Assign all children of pathContainer as the path nodes
            Transform[] nodes = new Transform[pathContainer.childCount];

            for (int i = 0; i < pathContainer.childCount; i++)
            {
                nodes[i] = pathContainer.GetChild(i);
            }

            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.nodes = nodes;

            enemyScript.spawner = this;// Give the enemy a reference to this spawner

            numOfEnemiesAlive++;
        }

    }

    public void EnemyDestroyed()
    {
        numOfEnemiesAlive--;
    }  
}
