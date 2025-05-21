using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject[] blocks;
    public Transform spawnPoint;

    void Start()
    {
        SpawnBlock();
        InvokeRepeating("SpawnBlock", 0, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnBlock()
    {
        int randomIndex = Random.Range(0, blocks.Length); //elije un numero entre 0 y el tamaño de la array
        GameObject block = Instantiate(blocks[randomIndex], transform.position, Quaternion.identity);
        block.transform.SetParent(transform); // hace que se muevan los hijos tambien.
    }
}