using UnityEngine;
public class normalTower : Tower
{
    public GameObject arrowPrefab;
    public GameObject gun;
    public Transform firePoint;

    protected override void Attack(GameObject enemy)
    {
        GameObject arrowGO = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Arrow arrow = arrowGO.GetComponent<Arrow>();
        Vector3 backupAngle = gun.transform.eulerAngles;
        gun.transform.LookAt(enemy.transform);
        gun.transform.eulerAngles = new Vector3(backupAngle.x, gun.transform.eulerAngles.y, gun.transform.eulerAngles.z);

        if (arrow != null)
        {
            arrow.Seek(enemy.transform);
            arrow.damage = this.damage; 
        }
    }
}