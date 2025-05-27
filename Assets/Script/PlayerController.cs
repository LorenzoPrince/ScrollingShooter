using UnityEngine;
using UnityEngine.InputSystem; // para usar el nuevo sistema
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth = 50;
    private int currentHealth;
    Vector2 InputMovement;
    public float moveSpeed = 5f;
    void Start()
    {

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

}
