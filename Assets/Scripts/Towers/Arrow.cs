using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;
    private float speed = 15f;
    public float damage = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    public void SetTarget(GameObject _target, float _damage)
    {
        target = _target.transform;
        damage = _damage;
    }

    void Update()
    {
        
        if (target == null)
        {
            Destroy(gameObject);
            return; 
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return; 
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        
        transform.LookAt(target);
    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Call the TakeDamage method on the enemy
            enemy.TakeDamage((int)damage);
        }

        // Destroy arrow
        Destroy(gameObject);
    }
}