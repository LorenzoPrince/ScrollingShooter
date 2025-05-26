using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update


    public int damage = 25;

    private void OnCollisionEnter(Collision contraLoQueChoque)
    {
 
        Debug.Log("la Bala choco con: " + contraLoQueChoque.gameObject.name);
        Destroy(gameObject);
    }

}
