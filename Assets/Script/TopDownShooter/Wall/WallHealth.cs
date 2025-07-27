using UnityEngine;

public class WallHealth : MonoBehaviour
{
    private int maxHealth = 100;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;   
    }

    // Update is called once per frame
    public void TakeDamage(int damage) //se llamara cuando el enemigo le hace daño
    {
        currentHealth -= damage;
        Debug.Log("Pared dañada. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

}
