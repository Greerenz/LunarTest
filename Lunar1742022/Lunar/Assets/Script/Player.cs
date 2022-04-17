using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TestSpawn testSpawn;

    private void Start()
    {
        testSpawn = GameManager.Instance.spawner;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            BulletDamage currentBullet = testSpawn.bullets[0].GetComponent<BulletDamage>();
            if (currentBullet.canReflect)
            {
                currentBullet.IsReflect = true;
                testSpawn.DespawnFirstBullet();
            }
        }
    }
}
