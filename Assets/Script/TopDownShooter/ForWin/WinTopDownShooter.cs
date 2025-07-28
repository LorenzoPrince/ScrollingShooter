using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinTopDownShooter : MonoBehaviour
{
    public int maxHealth = 500;
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
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Pared dañada. Vida restante: " + currentHealth);
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("choque contra " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Shoot"))
        {
            BulletDamage bulletDamage = collision.gameObject.GetComponent<BulletDamage>(); //detecta si esta el script bullet en lo que impacta 
            if (bulletDamage != null)
            {
                TakeDamage((int)bulletDamage.damage); //saca ese daño
                Destroy(collision.gameObject);
            }
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


        SceneManager.LoadScene("Video");

    }

}