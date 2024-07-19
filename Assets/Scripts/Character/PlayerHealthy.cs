using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class PlayerHealthy : MonoBehaviour
{   
    ObjectPool objectPool;
    PlayerData playerData;

    private int _currectPlayerHealth;

    private void Awake()
    {
        objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
        playerData = GetComponent<PlayerData>();
    }

    private void OnEnable() => Restore();

    public void HealthChange(int damage)
    {
        _currectPlayerHealth = Mathf.Clamp(_currectPlayerHealth, 0, playerData._maxHealth);
        _currectPlayerHealth -= damage;
        if (_currectPlayerHealth <= 0)
        {
            Dead();
        }
        Debug.Log($"Моё здоровье:{_currectPlayerHealth}");  
    }

    private void Restore() => _currectPlayerHealth = playerData._maxHealth;

    private void Dead()
    {
        objectPool.DestroyObject(gameObject);
    }
}
