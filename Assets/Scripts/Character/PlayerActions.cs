using UnityEditor;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    ObjectPool objectPool;
    Rigidbody rbPlayer;
    PlayerData playerData;

    private ProjectileTypes projectileTypes;

    void Start()
    {
        objectPool = GameObject.Find("Pool").GetComponent<ObjectPool>();
        playerData = GetComponent<PlayerData>();
        rbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        projectileTypes = playerData.projectileType;
        float intputHorizontal = Input.GetAxis("Horizontal");
        CharacterMoveHorizontal(intputHorizontal);
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }
    }

    //Передвижение
    private void CharacterMoveHorizontal(float inputHorizontal)
    {
        Vector3 movement = new Vector3(inputHorizontal, 0f, 0f) * playerData._speed * Time.deltaTime;
        rbPlayer.MovePosition(transform.position + movement);
    }

    //Стрельба
    private void Shoot()
    {
        switch (projectileTypes) 
        {
            case ProjectileTypes.Arrow:
                GameObject Arrow = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Arrow);
                Arrow.transform.position = transform.position + new Vector3(0, 0, 2);
                break;
            case ProjectileTypes.Fireball:
                GameObject Fireball = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Fireball);
                Fireball.transform.position = transform.position + new Vector3(0, 0, 2);
                break;
            case ProjectileTypes.Rock:
                GameObject Rock = objectPool.GetObject(ObjectPool.ObjectsInfo.ObjectType.Rock);
                Rock.transform.position = transform.position + new Vector3(0, 0, 2);
                break;
        }
    }

}






