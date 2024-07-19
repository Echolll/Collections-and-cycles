using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField][Range(0, 15)] private float _spawnInterval;
    [Serializable] public struct EntitysInfo
    {
        public EntytisTypes _entytis;
        public Transform _transform;
        public bool _isSpawning;
    }

    [SerializeField]
    List<EntitysInfo> entitysInfos;

    ObjectPool objectPool;

    private void Awake() => objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();

    private void Start()
    {
        SpawnEntitys();
    }

    private void SpawnEntitys()
    {
        foreach(EntitysInfo entitysInfo in entitysInfos)
        {
            if (!entitysInfo._isSpawning)
            {
                EntytisTypes entityType = entitysInfo._entytis;
                switch (entityType)
                {
                    case EntytisTypes.Player:
                        GameObject Player = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Player);
                        Player.transform.position = entitysInfo._transform.position;
                        break;
                    case EntytisTypes.Elf:
                        GameObject Elf = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Elf);
                        Elf.transform.position = entitysInfo._transform.position;
                        break;
                    case EntytisTypes.Wizard:
                        GameObject Wizard = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Wizard);
                        Wizard.transform.position = entitysInfo._transform.position;
                        break;
                    case EntytisTypes.Ork:
                        GameObject Ork = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Ork);
                        Ork.transform.position = entitysInfo._transform.position;
                        break;

                }              
            }
        }      
    }
}
