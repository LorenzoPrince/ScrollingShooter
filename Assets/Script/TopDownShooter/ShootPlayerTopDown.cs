using UnityEngine;
using UnityEngine.InputSystem;


public class ShootPlayerTopDown : ShootingTopDown
{

    public void Onfire(InputAction.CallbackContext context)
    {
        if (context.performed) // que se active sol9 una cvez cyando toque
        {

            Shoot();
        }
    }
}