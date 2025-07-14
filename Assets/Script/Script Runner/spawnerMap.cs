using UnityEngine;

public class spawnerMap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject[] blocks;
    public Transform spawnPoint;

    void Start()
    {
        SpawnBlock();
        InvokeRepeating("SpawnBlock", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnBlock()
    {
        int randomIndex = Random.Range(0, blocks.Length); //elije un numero entre 0 y el tamaño de la array
        GameObject block = Instantiate(blocks[randomIndex], spawnPoint.position, blocks[randomIndex].transform.rotation); //hago que respete el angulo
        block.transform.SetParent(transform); // hace que se muevan los hijos tambien.
    }
}
