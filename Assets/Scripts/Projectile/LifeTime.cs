using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    ObjectPool objectPool;
    ProjectileData projectile;
    private float currectTime;

    private void Awake()
    {
        projectile = GetComponent<ProjectileData>();
        objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
    }

    private void OnEnable() => LifeTimeRestore();

    private void LifeTimeRestore() => currectTime = default;

    private void Update() => ProjectileLifeTime();

    private void ProjectileLifeTime()
    {
        currectTime += Time.deltaTime;

        if (currectTime >= projectile._lifeTime)
            ObjectPool.Instance.DestroyObject(gameObject);
    }
}
