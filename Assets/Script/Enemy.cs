using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 10f;
    [SerializeField] private float fireRate = 5f;

    private float nextFireTime;

    [SerializeField] private Transform[] firePoints;

    public int maxHealth = 50;
    private int currentHealth;
    void Start()
    {
        nextFireTime = Time.time;
        currentHealth = maxHealth; // Inicializar vida
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootForward();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootForward()
    {

        foreach (Transform firePoint in firePoints)
        {
            Vector3 direction = firePoint.forward;

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
            // Obtener script de la bala para el daño
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }

            Destroy(collision.gameObject); // Destruir la bala al impactar
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
