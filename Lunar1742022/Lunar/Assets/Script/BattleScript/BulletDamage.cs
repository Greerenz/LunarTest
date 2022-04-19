using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    GameObject AllyPostion;
    GameObject EnemyPostion;
    public float speed;
    SpriteRenderer ColorChange;
    public bool canReflect;
    public bool isReflect;
    public int bulletDamage;
    public bool IsReflect
    {
        set
        {
            isReflect = value;
            if (isReflect)
            {
                Debug.Log("Reflect");
            }
        }
        get
        {
            return isReflect;
        }
    }
    void Start()
    {
        ColorChange = GetComponent<SpriteRenderer>();
        AllyPostion = GameObject.FindGameObjectWithTag("Player");
        EnemyPostion = GameObject.FindGameObjectWithTag("Enem");
        Change();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReflect)
        {
                transform.position = Vector2.MoveTowards(transform.position, AllyPostion.transform.position, speed );
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyPostion.transform.position, speed * 2.5f);
        }
    }

    private void Change()
    {
        switch (Enemy.ElementLADDER)
        {
            case "Fire":
                ColorChange.color = Color.red;
                break;
            case "Water":
                ColorChange.color = Color.blue;
                break;
            case "Earth":
                ColorChange.color = Color.yellow;
                break;
            case "Wind":
                ColorChange.color = Color.green;
                break;
        }    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isReflect) 
        {
            if (other.CompareTag("Player"))
            {
                other.SendMessage("GetAttack", 1);
                GameManager.Instance.spawner.Despawn(this.gameObject);
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Enem"))
            {
                other.SendMessage("GetAttack", bulletDamage);
                GameManager.Instance.spawner.Despawn(this.gameObject);
                Destroy(this.gameObject);
            }
        }

        if (other.CompareTag("HitArea"))
        {
            canReflect = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HitArea"))
        {
            canReflect = false;
        }
    }
   
}
