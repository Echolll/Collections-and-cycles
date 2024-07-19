using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour , IHaveHealth, ICanMove , IPooledObject
{
    [SerializeField] public int _maxHealth;
    [SerializeField] public float _speed;    
    [SerializeField] public ProjectileTypes _projectileType;

    public ProjectileTypes projectileType => _projectileType;
    public float Speed => _speed;
    public int Health => _maxHealth;
    public ObjectPool.ObjectsInfo.ObjectType Type => type;
    [SerializeField] private ObjectPool.ObjectsInfo.ObjectType type;
}
