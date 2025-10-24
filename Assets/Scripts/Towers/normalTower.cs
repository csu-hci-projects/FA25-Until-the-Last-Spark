using UnityEngine;
public class normalTower : Tower
{
    public GameObject arrowPrefab;
    public Transform firePoint;

    protected override void Attack(GameObject enemy)
    {
        GameObject arrowGO = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrow = arrowGO.GetComponent<Arrow>();

        if (arrow != null)
        {
            arrow.Seek(enemy.transform);
            arrow.damage = this.damage; 
        }
    }
}