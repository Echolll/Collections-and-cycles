using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Acceleration : MonoBehaviour
{
    ProjectileData projectile;
   
    private void Awake() => projectile = GetComponent<ProjectileData>();

    private void Update() => Accelerate();
    
    private void Accelerate() => transform.Translate(projectile._speed * Time.deltaTime * Vector3.forward);
}
