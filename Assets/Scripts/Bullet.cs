using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;

    private Rigidbody2D rb;
    private IObjectPool<Bullet> bulletPool;  // Reference to the Object Pool

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Method to set the pool reference from Weapon
    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    // Launch the bullet with speed
    public void Launch()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    // Return bullet to the pool when it goes off-screen
    private void OnBecameInvisible()
    {
        ReturnToPool();
    }

    // Example of collision handling - bullet will return to pool on collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Implement logic to deal damage or other effects here
        ReturnToPool();
    }

    // Method to return the bullet to the pool
    private void ReturnToPool()
    {
        if (bulletPool != null)
        {
            bulletPool.Release(this);
        }
        else
        {
            Destroy(gameObject);  // Fallback if no pool is assigned
        }
    }
}

