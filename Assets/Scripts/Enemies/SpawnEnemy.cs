using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject strongEnemyPrefab;
    [SerializeField] Transform pathContainer;

    [SerializeField] float spawnInterval = 2f;
    private int numOfEnemiesKilled = 1;

    private int enemiesSpawned = 0;

    [SerializeField] int maxEnemies = 50;

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
        enemiesSpawned++;
        if (enemiesSpawned < maxEnemies)
        {
            GameObject enemy;
            // Spawn the enemy at the first node
            if (enemiesSpawned % 10 != 0)
            {
                enemy = Instantiate(enemyPrefab, pathContainer.GetChild(0).position, Quaternion.identity);
            }
            else{
                
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

        }

    }

    public void EnemyDestroyed()
    {
        numOfEnemiesKilled++;
    }  
}
