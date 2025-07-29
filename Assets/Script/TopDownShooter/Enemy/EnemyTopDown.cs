using UnityEngine;
using UnityEngine.AI;
public class EnemyTopDown : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    private WallHealth targetWall;
    public int damage = 5;
    public float damageInterval = 1f;
    private bool isAttacking = false;
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
            //Debug.Log("El enemigo está siguiendo al jugador: " + player.position);
        }
        else
        {
            Debug.LogWarning("El jugador no se ha encontrado");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("choque contra " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Shoot"))
        {
            GameData.killCountFloot++;
            Destroy(gameObject);
            Destroy(collision.gameObject); //destruyo la bala
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            targetWall = collision.gameObject.GetComponent<WallHealth>();
            if (targetWall != null && !isAttacking)
            {
                isAttacking = true;
                InvokeRepeating(nameof(DoDamage), 0f, damageInterval);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isAttacking = false;
            CancelInvoke(nameof(DoDamage));
        }
    }
    void DoDamage()
    {
        if (targetWall != null)
        {
            targetWall.TakeDamage(damage);
            Debug.Log("Daño aplicado al muro: " + damage);
        }
    }
}