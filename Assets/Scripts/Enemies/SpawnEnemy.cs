using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] Transform pathContainer;

    [SerializeField] float spawnInterval = 2f;
    private int numOfEnemiesAlive = 0;

    [SerializeField] int maxEnemies = 5;

    private bool wave1Start = true;
    private bool wave2Start = false;
    private bool wave3Start = false;
    private bool wave4Start = false;
    private bool levelFinished = false;

    void Start()
    {
        wave1Start = true;
        wave2Start = false;
        wave3Start = false;
        wave4Start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLoopManager.wave == 1 && wave1Start)
        {
            StartCoroutine(spawnWave1());
        }
        
        if(GameLoopManager.wave == 2 && wave2Start)
        {
            StartCoroutine(spawnWave2());
        }

        if(GameLoopManager.wave == 3 && wave3Start)
        {
            StartCoroutine(spawnWave3());
        }

        if(GameLoopManager.wave == 4 && wave4Start)
        {
            StartCoroutine(spawnWave4());
        }

        if(GameLoopManager.wave == 4 && levelFinished == true && numOfEnemiesAlive == 0)
        {
            SceneManager.LoadScene(3); //Win Scene
        }
    }

    private void Spawn(int enemyPrefabNum)
    {
        if (numOfEnemiesAlive < maxEnemies)
        {
            // Spawn the enemy at the first node
            GameObject enemy = Instantiate(enemyPrefab[enemyPrefabNum], pathContainer.GetChild(0).position, Quaternion.identity);

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

    IEnumerator spawnWave1()
    {
        Debug.Log("Wave 1");
        wave1Start = false;
        for (int i = 0; i < 7; i++)
        {
            Spawn(0);
            yield return new WaitForSeconds(2f);
        }

        for (int i = 0; i < 15; i++)
        {
            Spawn(0);
            yield return new WaitForSeconds(1f);
        }
        wave2Start = true;
    }

    IEnumerator spawnWave2()
    {
        Debug.Log("Wave 2");
        wave2Start = false;
        for (int i = 0; i < 5; i++)
        {
            Spawn(0);
            yield return new WaitForSeconds(2f);
        }
        for (int i = 0; i < 7; i++)
        {
            Spawn(1);
            yield return new WaitForSeconds(.3f);
            Spawn(0);
            yield return new WaitForSeconds(1.5f);
        }
        for (int i = 0; i < 20; i++)
        {
            Spawn(0);
            yield return new WaitForSeconds(.5f);
        }
        for (int i = 0; i < 10; i++)
        {
            Spawn(1);
            yield return new WaitForSeconds(1f);
        }
        wave3Start = true;
    }

    IEnumerator spawnWave3()
    {
        Debug.Log("Wave 3");
        wave3Start = false;
        for (int i = 0; i < 20; i++)
        {
            Spawn(2);
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 20; i++)
        {
            Spawn(2);
            Spawn(0);
            yield return new WaitForSeconds(.5f);
        }
        for (int i = 0; i < 20; i++)
        {
            Spawn(0);
            yield return new WaitForSeconds(.3f);
            Spawn(1);
            yield return new WaitForSeconds(.3f);
            Spawn(2);
            yield return new WaitForSeconds(.5f);
        }
        wave4Start = true;
    }

    IEnumerator spawnWave4()
    {
        Debug.Log("Wave 4");
        wave4Start = false;
        for (int i = 0; i < 5; i++)
        {
            Spawn(0);
            yield return new WaitForSeconds(.3f);
            Spawn(1);
            yield return new WaitForSeconds(.5f);
        }
        Spawn(3);
        yield return new WaitForSeconds(8f);
        for (int i = 0; i < 30; i++)
        {
            Spawn(2);
            yield return new WaitForSeconds(.1f);
        }
        Spawn(3);
        yield return new WaitForSeconds(.8f);
        Spawn(3);
        levelFinished = true;
    }

}