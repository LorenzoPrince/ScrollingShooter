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
    }

    IEnumerator ActivarMenuDespuesDeSegundos(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        Debug.Log("Activando panel despu�s de " + segundos + " segundos");
        panelMenu.SetActive(true);
    }


    public void ReturnGame()
    {
        SceneManager.LoadScene("Game"); // Reemplaz� con tu escena real

    }
    public void Exit()
    {

        Application.Quit();
    }
}
