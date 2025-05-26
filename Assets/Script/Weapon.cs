using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float bulletForce; //es para que sea privado pero se siga viendo en el inspector y editarlo, pero no podes editarlo en otro script. 
    [SerializeField] private GameObject objectPrefab;
   // [SerializeField] private GameObject shootVFXPrefab; // Prefab de las part�culas del disparo
    public Vector3 spawnPosition;
    //private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //hago referencia a script notas
        {
            //audioSource.Play();
            weapon();
        }
    }
    [SerializeField]
    void weapon()
    {
        Cursor.visible = false;

        GameObject bulletClone = Instantiate(objectPrefab, transform.position, transform.rotation); // el quaternion. identity es para que sea en la misma posicion que el vector . y el vector que esta el spawn


        Rigidbody bulletRigidBody = bulletClone.GetComponent<Rigidbody>(); //rigid body de la nueva bala

        bulletRigidBody.linearVelocity = transform.forward * bulletForce; // impulso de la bala multiplicado por el bulletforce


        // Instanciar el efecto de part�culas en la misma posici�n del disparo

        Destroy(bulletClone, 2f);
        // en el prefab de la bala hago que si se choca contra algo se elimine la bala pero esto en el prefab
    }

}
