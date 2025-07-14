using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float distance = 4f; // en la que se mueva
    private int actual = 1; // 1 centro seria 2 derecha 0 izquierda
    public float cambioSpeed = 5f; // velocidad hacia adelante

    private float posicionActual;


    public int coins = 0;
    private void Awake()
    {
        actual = 1;


    }
        void Start()
    {
        Time.timeScale = 1f;
        posicionActual = actual * distance; //para que inicie en el 1
        transform.position = new Vector3(transform.position.x, transform.position.y, posicionActual);



    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (actual > 0)
            {
                actual--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (actual < 2)
            {
                actual++;

            }
        }

        posicionActual = actual * distance;
        Vector3 posicion = new Vector3(transform.position.x, transform.position.y, posicionActual); //agarra la distancia del nuevo vector
        transform.position = Vector3.Lerp(transform.position, posicion, Time.deltaTime * cambioSpeed); //lo mueve al vector
    }
 
    public void Rejugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}



