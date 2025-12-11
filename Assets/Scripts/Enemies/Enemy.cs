using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]  int health = 100;
    [SerializeField]  int speed = 10;
    [SerializeField] private int moneyReward = 1;
    [SerializeField] private int damageFactor = 1;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hitSound;

    public Transform[] nodes;
    public SpawnEnemy spawner;

    private int currentNode = 0;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nodes == null || nodes.Length == 0) return;

        // Move toward the current node
        Transform target = nodes[currentNode];
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Check if reached node
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentNode++;
            if (currentNode >= nodes.Length)
            {
                // Reached end of path
                enabled = false; // stop moving
                spawner.EnemyDestroyed();
                Destroy(gameObject);
                GameLoopManager.health -= damageFactor;
            }
        }

        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, 0.4f);

            spawner.EnemyDestroyed();
            GameLoopManager.money += moneyReward; //Reward player with money for destroying enemy
            Destroy(gameObject);
            
        }

    }
    
/*
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(10);
            GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("Something hit me!");
        }
    }
*/

    public void TakeDamage(int damage)
    {
        health -= damage;
        AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, 0.1f);
    }
}
