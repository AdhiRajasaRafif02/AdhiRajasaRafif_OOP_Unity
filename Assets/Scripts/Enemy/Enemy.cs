using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
[SerializeField] public int level;
public EnemySpawner enemySpawner;

public CombatManager combatManager;

public UnityEvent enemyKilledEvent;

private void Start()
{
enemyKilledEvent ??= new UnityEvent();
}

public void SetLevel(int level)
{
this.level = level;
}

public int GetLevel()
{
return level;
}

private void OnDestroy()
{
    if (enemySpawner != null && combatManager != null)
        {
            enemySpawner.OnDeath();
            combatManager.RegisterKill();
        }
enemyKilledEvent.Invoke();
}
}
