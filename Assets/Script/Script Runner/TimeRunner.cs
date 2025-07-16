using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TimeRunner : MonoBehaviour
{
    private float tiempoParaCambiarEscena = 15f;
    void Start()
    {
        StartCoroutine(CambiarEscenaCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CambiarEscenaCoroutine()
    {
        yield return new WaitForSeconds(tiempoParaCambiarEscena);
        Debug.Log("Tiempo cumplido, cambiando escena con Coroutine");
        SceneManager.LoadScene("Plataform");
    }
    void CambiarEscena()
    {
        Debug.Log("Tiempo fue cumplid cambiando escena con invoke");
        SceneManager.LoadScene("Plataform");
    }
}


