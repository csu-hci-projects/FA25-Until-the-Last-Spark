using UnityEngine;
public class normalTower : Tower
{
    // You can add properties unique to this tower
    public GameObject arrowPrefab;
    public Transform firePoint;

    // The "abstract" rule in Tower.cs FORCES you to write this method.
    // This is where you put your unique attack logic.
    protected override void Attack(GameObject enemy)
    {
        // 1. Create an arrow from the prefab
        GameObject arrowGO = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        
        // 2. Get the Arrow script component from the new arrow
        Arrow arrow = arrowGO.GetComponent<Arrow>();

        // 3. Set the arrow's target and damage
        if (arrow != null)
        {
            // Tell the arrow which enemy to seek (pass the enemy's Transform)
            arrow.Seek(enemy.transform);
            
            // Set the arrow's damage to be this tower's damage
            // 'damage' is the float variable inherited from the base 'Tower' class
            arrow.damage = this.damage; 
        }
    }
}