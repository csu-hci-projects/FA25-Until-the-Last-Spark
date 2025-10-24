using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]  int health = 100;
    [SerializeField]  int speed = 10;

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
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Check if reached node
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentNode++;
            if (currentNode >= nodes.Length)
            {
                // Reached end of path
                enabled = false; // stop moving
            }
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
        if (health <= 0)
        {
            spawner.EnemyDestroyed();
            Destroy(gameObject);
            
        }
        Debug.Log("Health: " + health);
    }
}
