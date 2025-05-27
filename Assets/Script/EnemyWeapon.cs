using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 10f;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private int maxHealth = 50;
    private int currentHealth;

    private float nextFireTime;



    [SerializeField] private Transform[] firePoints; // Array de spawns para disparar desde varios puntos

    private Transform target; // El jugador u otro objetivo

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nextFireTime = Time.time;
        currentHealth = maxHealth;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }

            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemigo recibe daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo destruido");
        Destroy(gameObject);
    }
}


