using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine;

public class ShootPlayerTopDown : ShootingTopDown
{
    public void Onfire(InputAction.CallbackContext context)
    {

        Shoot();
    }
}