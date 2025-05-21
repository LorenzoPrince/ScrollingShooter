using UnityEngine;
using UnityEngine.InputSystem; // para usar el nuevo sistema
public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector2 InputMovement;
    public float moveSpeed = 5f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(InputMovement.x * moveSpeed * Time.deltaTime, InputMovement.y * moveSpeed * Time.deltaTime, 0);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        InputMovement = context.ReadValue<Vector2>();
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed) // Esto se fija que el disparo solo ocurre una vez cuando se presiona el botón, y no mientras se mantiene presionado.
        {
            Debug.Log("Fire");
        } 
    }
}
