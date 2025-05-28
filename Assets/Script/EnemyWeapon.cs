using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 10f;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int collisionDamage = 50; //Da�o al chocar
    private int currentHealth;

    private float nextFireTime;

        public EnemyWeapon leftEscort;
    public EnemyWeapon rightEscort;


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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {                           //DA�OOO
                player.TakeDamage(collisionDamage); // Le quitamos 50 de vida por contacto (ajust� el valor que quieras)
            }

            Destroy(gameObject); // El enemigo se destruye al tocar al jugador
        }
        if (other.CompareTag("BulletPlayer"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }

            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateBossHealth(currentHealth);
        }

        Debug.Log("Enemigo recibe da�o. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.None;
        Vector3 impulseDirection = transform.forward;
        rb.AddForce(impulseDirection * 50f, ForceMode.Impulse);
        // Aplica torque para que gire 
        Vector3 randomTorque = new Vector3(50f, 50f, 50f);
        rb.AddTorque(randomTorque, ForceMode.Impulse);
        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddKill();
            UIManager.Instance.HideBossUI();
        }
        else
        {
            Debug.LogWarning("UIManager.Instance es null");
        }

        Debug.Log("Enemigo destruido");

        // Destruir el objeto despu�s de unos segundos para que se vea la f�sica
        Destroy(gameObject, 4f);
    }
    public void SetMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;

        // Si tienes la barra de vida , actual�zala aca tambi�n
    }
    public void SetBulletForce(float newBulletForce)
    {
        bulletForce = newBulletForce;
    }
    public void SetFireRate(float newRate)
    {
        fireRate = newRate;
    }
}


