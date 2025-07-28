using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WallHealth : MonoBehaviour
{
    public int maxHealth = 200;
    private int currentHealth;

    public Slider healthSlider;
    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }


    public void TakeDamage(int damage) //se llamara cuando el enemigo le hace daño
    {
        currentHealth -= damage;
        Debug.Log("Pared dañada. Vida restante: " + currentHealth);


        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
    void Die()
    {
        Debug.Log("muro destruido!");

        SceneManager.LoadScene("DeathTopDown");

    }

}
