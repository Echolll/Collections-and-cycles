using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileData : MonoBehaviour , ICanMove , IHaveLifeTime , IPooledObject
{
    [SerializeField] public float _speed;
    [SerializeField] public float _lifeTime;
    [SerializeField] public int _damage;

    public abstract ProjectileTypes Types { get; }
    public float Speed => _speed;
    public float LifeTime => _lifeTime;

    public ObjectPool.ObjectsInfo.ObjectType Type => type;
    [SerializeField] private ObjectPool.ObjectsInfo.ObjectType type;
}
