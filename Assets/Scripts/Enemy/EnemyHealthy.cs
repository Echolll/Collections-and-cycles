using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class EnemyHealthy : MonoBehaviour
{   
    ObjectPool objectPool;
    EnemyData enemyData;

    private int _currectEnemyHealth;

    private void Awake()
    {
        objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
        enemyData = GetComponent<EnemyData>();
    }

    private void OnEnable() => Restore();

    private void Update()
    {
        if (_currectEnemyHealth == 0)
        {
            Dead();
        }
    }

    public void HealthChange(int damage)
    {
        _currectEnemyHealth = Mathf.Clamp(_currectEnemyHealth, 0, enemyData._maxHealth);
        _currectEnemyHealth -= damage;
        Debug.Log($"Здоровье противника:{_currectEnemyHealth}");
    }

    private void Restore() => _currectEnemyHealth = enemyData._maxHealth;

    private void Dead()
    {
        objectPool.DestroyObject(gameObject);
        
    }

}
