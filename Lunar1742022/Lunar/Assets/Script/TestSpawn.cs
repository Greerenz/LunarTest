using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public List<GameObject> bullets = new List<GameObject>();
    public float repeatRate = 0.5f;
    public bool EnemyAttack;
    public bool wait;
    private void Start()
    {
       
           // InvokeRepeating(nameof(Spawn), 1, repeatRate);
       
        
    }


    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (EnemyAttack)
        {
            if (GameManager.Instance.enemy.ElemtGage >= 1)
            {
                if (!wait)
                {
                    StartCoroutine(Wait());
                }
            }
        }
    }

    IEnumerator Wait()
    {
        wait = true;
        GameManager.Instance.enemy.ElemtGage -= 1;
        GameObject currentBullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
        bullets.Add(currentBullet);
        yield return new WaitForSeconds(repeatRate);
        wait = false;
    }
    public void DespawnFirstBullet()
    {
        bullets.RemoveAt(0);
    }

    public void Despawn(GameObject currentObject)
    {
        bullets.Remove(currentObject);
    }
}
