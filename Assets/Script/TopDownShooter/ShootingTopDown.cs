using UnityEngine;
using System.Collections;
public class ShootingTopDown : MonoBehaviour
{
    public AudioSource blaster;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    private float shootCooldown = 1.5f; // Tiempo entre disparos
    private bool puedeDisparar = true;

    public void Shoot()
    {
        if (!puedeDisparar) return;
        StartCoroutine(DisparoConCooldown());
    }
    IEnumerator DisparoConCooldown() // si no pongo que es unity lo toma como privado
    {
        puedeDisparar = false;
        if (bulletPrefab == null || firePoint == null) yield break;


        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        blaster.Play();
        bullet.transform.rotation = Quaternion.Euler(0, 0, 90); 

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {

            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }


        Destroy(bullet, 4f);
        yield return new WaitForSeconds(shootCooldown);
        puedeDisparar = true;
    }
}


