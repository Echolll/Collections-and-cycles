using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooledObject
{
    ObjectPool.ObjectsInfo.ObjectType Type { get; }
}
