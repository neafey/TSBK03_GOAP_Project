using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isHit = false;

    public float speed = 2f; // Movement speed of the enemy
    private Transform npc;
    

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
                npcComponent.TakeDamage(10, 5);
            }

            Destroy(gameObject);
        }
    }

    public void GetHit()
    {
        if (!isHit)
        {
            isHit = true;
            Destroy(gameObject); 
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
