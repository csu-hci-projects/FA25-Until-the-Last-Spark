
using UnityEngine;

public class GunnerTower : Tower
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    protected override void Attack(GameObject enemy)
    {
        // Instantiate a bullet and set its target
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Arrow b = bullet.GetComponent<Arrow>();
            if (b != null)
            {
                b.SetTarget(enemy, damage);
            }
        }
    }

    public override void Upgrade()
    {
        base.Upgrade();
        attackRate *= 1.1f; // Example: increase attack speed
    }
}

