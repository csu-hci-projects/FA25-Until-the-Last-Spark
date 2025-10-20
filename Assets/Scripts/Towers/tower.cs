/*
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    // Tower stats
    [Header("Tower Stats")]
    public float health = 100f;
    public float damage = 10f;
    public float attackRange = 5f;
    public float attackRate = 1f; // attacks per second
    public string element = "None"; // e.g., Fire, Ice, etc.

    // Upgrade levels
    public int upgradeLevel = 0;

    // Timer for attack rate
    protected float attackCooldown = 0f;

    // Targeting
    protected GameObject target;

    // Called every frame
    protected virtual void Update()
    {
        // Countdown for attack cooldown
        attackCooldown -= Time.deltaTime;

        // Attempt to attack if ready
        if (attackCooldown <= 0f)
        {
            AcquireTarget();
            if (target != null)
            {
                Attack(target);
                attackCooldown = 1f / attackRate;
            }
        }
    }

    // Method to acquire a target (can be overridden)
    protected virtual void AcquireTarget()
    {
        // Example: find closest enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= attackRange)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        target = nearestEnemy;
    }

    // Method to attack a target (must be overridden)
    protected abstract void Attack(GameObject enemy);

    // Method for taking damage
    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    // Method called on tower death
    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    // Method to upgrade the tower
    public virtual void Upgrade()
    {
        upgradeLevel++;
        damage *= 1.2f; // Example: increase damage by 20%
        health *= 1.1f; // Example: increase health by 10%
    }
}
*/