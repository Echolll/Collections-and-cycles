using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyActions : MonoBehaviour
{
    EnemyData enemyData;
    ObjectPool objectPool;

    [SerializeField] Transform target;
    private float attackDistance;
    private float attackSpeed;

    private bool canAttack = true;
    private ProjectileTypes projectileTypes;

    private void Awake()
    {
        objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
        enemyData = GetComponent<EnemyData>();
    }

    private void OnEnable()
    {
        attackDistance = enemyData._attackDistance;
        attackSpeed = enemyData._attackSpeed;
        projectileTypes = enemyData._projectileType;
    }

    private void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) < attackDistance) 
        {
            transform.LookAt(target);
            if (canAttack) 
            {
                Attack();
                StartCoroutine(AttackDelay());
            }
        }    
    }

    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

    void Attack()
    {
        switch (projectileTypes)
        {
            case ProjectileTypes.Arrow:
                GameObject Arrow = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Arrow);
                Arrow.transform.position = transform.position + new Vector3(0, 0, -2);
                Arrow.transform.LookAt(target);
                break;
            case ProjectileTypes.Fireball:
                GameObject Fireball = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Fireball);
                Fireball.transform.position = transform.position + new Vector3(0, 0, -2);
                Fireball.transform.LookAt(target);
                break;
            case ProjectileTypes.Rock:
                GameObject Rock = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Rock);
                Rock.transform.position = transform.position + new Vector3(0, 0, -2);
                Rock.transform.LookAt(target);
                break;
        }
    }

}
