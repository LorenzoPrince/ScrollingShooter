using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerTopDown : MonoBehaviour
{
    public string tagEnemigo = "Enemy";           // Tag que tienen los enemigos


    public float checkInterval = 1f; // cada cuántos segundos revisar
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f;

            GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tagEnemigo);

            if (enemigos.Length == 0)
            {
                Debug.Log("No quedan enemigos. Cambiando de escena...");
                SceneManager.LoadScene("Video");
            }
            else
            {
                Debug.Log("Enemigos vivos: " + enemigos.Length);
            }
        }
    }
}
