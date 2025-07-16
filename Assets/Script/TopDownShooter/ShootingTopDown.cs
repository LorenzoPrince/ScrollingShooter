using UnityEngine;

public class ShootingTopDown : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
  


    public void Shoot() // si no pongo que es unity lo toma como privado
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.transform.rotation = Quaternion.Euler(0, 0, 90); 

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        Destroy(bullet, 4f);

    }
}


