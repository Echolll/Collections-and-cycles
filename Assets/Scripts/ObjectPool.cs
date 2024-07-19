using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   public static ObjectPool Instance;

    
    [Serializable] public struct ObjectsInfo
    {
        public enum ObjectType
        {
            Arrow,
            Rock,
            Fireball,
            Player,
            Elf,
            Ork,
            Wizard
        }

        public ObjectType Type;
        public GameObject Prefab;
        public int StartCount;  
    }

    [SerializeField]
    private List<ObjectsInfo> objectsInfo;

    private Dictionary<ObjectsInfo.ObjectType, Pool> pools;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        InitPool();
    }

    private void InitPool()
    {
        pools = new Dictionary<ObjectsInfo.ObjectType, Pool>();

        var emptyGO = new GameObject();

        foreach (var obj in objectsInfo) 
        {
            var container = Instantiate(emptyGO, transform, false);
            container.name = obj.Type.ToString();

            pools[obj.Type] = new Pool(container.transform);

            for (int i = 0; i < obj.StartCount; i++)
            {
                var go = InstantiateObject(obj.Type,container.transform);
                pools[obj.Type].Objects.Enqueue(go);
            }
        }

        Destroy(emptyGO);
    }

    private GameObject InstantiateObject(ObjectsInfo.ObjectType type, Transform parent)
    {
        var go = Instantiate(objectsInfo.Find(x => x.Type == type).Prefab, parent);
        go.SetActive(false);
        return go;
    }

    public GameObject GetObject(ObjectsInfo.ObjectType type)
    {
        var obj = pools[type].Objects.Count > 0 ?
            pools[type].Objects.Dequeue() : InstantiateObject(type, pools[type].Container);

        obj.SetActive(true);

        return obj;
    }

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<IPooledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
    }
}

