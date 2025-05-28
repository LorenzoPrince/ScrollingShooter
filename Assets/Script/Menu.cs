using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Menu : MonoBehaviour
{
    public GameObject panelMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        Debug.Log("Start corriendo en escena: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Video")
        {
            StartCoroutine(ActivarMenuDespuesDeSegundos(10));
        }
        if (SceneManager.GetActiveScene().name == "Death")
        {
            StartCoroutine(ActivarMenuDespuesDeSegundos(3));
        }
    }

    IEnumerator ActivarMenuDespuesDeSegundos(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        Debug.Log("Activando panel después de " + segundos + " segundos");
        panelMenu.SetActive(true);
    }

    IEnumerator ActivarMenuDeath(float segundo)
    {
        yield return new WaitForSeconds(segundo);
        Debug.Log("Activando panel después de " + segundo + " segundos");
        panelMenu.SetActive(true);
    }
    public void ReturnGame()
    {
        SceneManager.LoadScene("Game"); // Reemplazá con tu escena real

    }
    public void Exit()
    {

        Application.Quit();
    }
}
