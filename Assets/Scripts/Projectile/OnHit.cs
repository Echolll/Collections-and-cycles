using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class OnHit : MonoBehaviour
{
    ObjectPool objectPool;
    ProjectileData projectile;
    
    private int damage;

    private void Awake()
    {
        objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
        projectile = GetComponent<ProjectileData>();
    }

    private void OnEnable()
    {
        damage = projectile._damage;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealthy enemyHealthy))
        {
            enemyHealthy.HealthChange(damage);
        }
        else if (other.TryGetComponent(out PlayerHealthy playerHealthy))
        {
            playerHealthy.HealthChange(damage);
        }
    }
}
