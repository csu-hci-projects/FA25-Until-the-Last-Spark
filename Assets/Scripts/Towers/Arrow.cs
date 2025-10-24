using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;
    private float speed = 15f;
    public float damage = 0f; // This will be set by the tower that fired it

    // The tower will call this method to give the arrow its target
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        // If the target is destroyed (e.g., another arrow hit it), destroy this arrow too.
        if (target == null)
        {
            Destroy(gameObject);
            return; 
        }

        // --- Move towards the target ---
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // Check if we are close enough to hit the target
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return; 
        }

        // Move the arrow
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        
        // Optional: Make the arrow point at the target
        transform.LookAt(target);
    }

    void HitTarget()
    {
        // Try to get the Enemy script from the target we hit
        Enemy enemy = target.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Call the TakeDamage method on the enemy
            // We cast our 'float' damage to an 'int' because the Enemy script expects an int
            enemy.TakeDamage((int)damage);
        }

        // Destroy the arrow projectile
        Destroy(gameObject);
    }
}