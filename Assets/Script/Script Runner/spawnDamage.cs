using Unity.VisualScripting;
using UnityEngine;

public class spawnDamage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject[] Enemys; //array para enemigos o disparos o etc. 


    public float distance = 4f; // en la que se mueva
    private int actual = 1; // 1 centro seria 2 derecha 0 izquierda
    public float cambioSpeed = 5f; // velocidad hacia los costados que se mueve
    public Transform spawnPoint;

    private float posicionActual;

    void Start()
    {
        posicionActual = actual * distance; //para que inicie en el 1
        transform.position = new Vector3(transform.position.x, transform.position.y, posicionActual);
        SpawnBlock();
        InvokeRepeating("SpawnBlock", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void SpawnBlock()
    {
        int randomIndex = Random.Range(0, Enemys.Length); //elije un numero entre 0 y el tamaño de la array
        int randomCarril = Random.Range(0,3); //elije un numero entre 0 y el 2 para el carril
        posicionActual = randomCarril * distance; //para que vaya cambiando la posicion del carril de forma random
        Vector3 posicion = new Vector3(transform.position.x, transform.position.y, posicionActual); //agarra la distancia del nuevo vector
        GameObject enemy = Instantiate(Enemys[randomIndex], posicion, Enemys[randomIndex].transform.rotation); //hago que respete el angulo
        enemy.transform.SetParent(transform); // lo hace hijo del spawner.
    }
}
