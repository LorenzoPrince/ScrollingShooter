using UnityEngine;

public class WinTopDownShooter : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage) //se llamara cuando el enemigo le hace daño
    {
        currentHealth -= damage;
        Debug.Log("Pared dañada. Vida restante: " + currentHealth);

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
            }
        }
    }
    void Die()
    {
        Debug.Log("muro destruido!");

        Destroy(gameObject);

    }

}