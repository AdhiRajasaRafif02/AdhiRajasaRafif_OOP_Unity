using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health;

    void Awake()
    {
        if (health == null)
        {
            health = GetComponent<HealthComponent>();
        }
    }

    public void Damage(int amount)
    {
        if (health != null)
        {
            health.Subtract(amount);
        }
    }

    public void Damage(Bullet bullet)
    {
        Damage(bullet.damage);
    }
}

