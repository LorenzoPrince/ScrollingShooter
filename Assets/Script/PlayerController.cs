using UnityEngine;
using UnityEngine.InputSystem; // para usar el nuevo sistema
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth = 100;
    private int currentHealth;

    Vector2 InputMovement;
    public float moveSpeed = 5f;

    void Start()
    {
        currentHealth = maxHealth; // Inicializamos vida
        Debug.Log("Vida inicial del jugador: " + currentHealth);
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(InputMovement.x * moveSpeed * Time.deltaTime, InputMovement.y * moveSpeed * Time.deltaTime, 0);

        Vector3 pos = transform.position;  // Obtener la posición actual del personaje


        pos.x = Mathf.Clamp(pos.x, -4.69f, 4.69f);  // Limitar eje X 


        pos.y = Mathf.Clamp(pos.y, -2.02f, 3.02f);

        // Aplicar la posición limitada al personaje
        transform.position = pos;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        InputMovement = context.ReadValue<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }
            Destroy(collision.gameObject);
        }
       
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Vida del jugador: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("¡Jugador muerto!");
        gameObject.SetActive(false); // Puedes usar solo esto o Destroy(gameObject)

    }
}