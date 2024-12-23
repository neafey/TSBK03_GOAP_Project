using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isHit = false; // Tracks if the enemy has been hit

    public float speed = 2f; // Movement speed of the enemy
    private Transform npc; // Reference to the NPC

    void Start()
    {
        npc = GameObject.FindGameObjectWithTag("NPC").transform;
    }

    void Update()
    {
        if (npc != null)
        {
            Vector2 direction = (npc.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            NPC npcComponent = collision.GetComponent<NPC>();
            if (npcComponent != null)
            {
                npcComponent.TakeDamage(10, 5); // Example: lose 10 health and 5 hunger
            }

            Destroy(gameObject); // Destroy the enemy
        }
    }

    public void GetHit()
    {
        if (!isHit)
        {
            isHit = true;
            Debug.Log($"{gameObject.name} has been hit!");
            Destroy(gameObject, 0.5f); // Destroy the enemy after a short delay
        }
    }

    private void OnDestroy()
    {
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.OnEnemyDestroyed();
        }
    }
}
