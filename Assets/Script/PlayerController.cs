using UnityEngine;
using UnityEngine.InputSystem; // para usar el nuevo sistema
using UnityEngine.SceneManagement;
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
        UIManager.Instance.UpdatePlayerHealth(currentHealth, maxHealth); // Actualizamos la UI al iniciar

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }

            Destroy(other.gameObject);
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UIManager.Instance.UpdatePlayerHealth(currentHealth, maxHealth);
        Debug.Log("Vida del jugador: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("¡Jugador muerto!");
        SceneManager.LoadScene("Death");
        gameObject.SetActive(false); // Puedes usar solo esto o Destroy(gameObject)

    }
}