using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 10f;
    [SerializeField] private float fireRate = 5f;

    private float nextFireTime;

    [SerializeField] private Transform[] firePoints; // Array de spawns para disparar desde varios puntos

    private Transform target; // El jugador u otro objetivo

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= nextFireTime) //para qeu dispare reiteradasveces
        {
            ShootAtTarget();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootAtTarget()
    {
        if (target == null || firePoints.Length == 0) // si no detecta el tag
            return;

        foreach (Transform firePoint in firePoints)
        {
            Vector3 direction = (target.position - firePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = direction * bulletForce;

            Destroy(bullet, 3f);
        }
    }
}


