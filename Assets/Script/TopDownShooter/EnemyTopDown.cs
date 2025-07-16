using UnityEngine;
using UnityEngine.AI;
public class EnemyTopDown : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("No se encontró al jugador con el tag 'Player'");
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
            Debug.Log("El enemigo está siguiendo al jugador: " + player.position);
        }
        else
        {
            Debug.LogWarning("El jugador no se ha encontrado");
        }
    }
}