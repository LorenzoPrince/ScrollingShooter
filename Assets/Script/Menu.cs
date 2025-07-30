using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Menu : MonoBehaviour
{
    public GameObject panelMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

 
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        Cursor.visible = true; // Lo hace visible

        Debug.Log("Start corriendo en escena: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Video")
        {
            StartCoroutine(ActivarMenuDespuesDeSegundos(10));
        }
        if (SceneManager.GetActiveScene().name == "Death")
        {
            StartCoroutine(ActivarMenuDespuesDeSegundos(3));
        }
        if (SceneManager.GetActiveScene().name == "DeathRunner")
        {
            StartCoroutine(ActivarMenuDespuesDeSegundos(3));
        }
        if (SceneManager.GetActiveScene().name == "DeathTopDown")
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
        SceneManager.LoadScene("Game"); 

    }
    public void Exit()
    {

        Application.Quit();
    }
    public void ReturnGameRunner()
    {
        SceneManager.LoadScene("Runner"); // cambia escena

    }

    public void ReturnGameTopDown()
    {
        SceneManager.LoadScene("TopDownShooter");
        Debug.Log("Reiniciando escena TopDownShooter...");
    }
}
