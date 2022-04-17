using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnbase : MonoBehaviour
{
    public static int Turn = 0;
    bool Check;
    private void Start()
    {
        Turn = 0;
        Debug.Log("Fight Start");
        SkillElement.SelectElem = true;
    }

    private void Update()
    {
        if (Turn == 1)
        {

                SkillElement.SelectElem = true;

        }   
        else if(Turn == 2)
        {
            if (!Check)
            {
                EnemyTurn();
                Check = true;
            }
            
        }
    }


    public void EnemyTurn()
    {
        StartCoroutine(Interact());
    }

    IEnumerator Interact()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Monster Talk");
        yield return new WaitForSeconds(2);
        GameManager.Instance.spawner.EnemyAttack = true;
        Debug.Log("EnemyAttack");
        yield return new WaitForSeconds(5);
        GameManager.Instance.spawner.EnemyAttack = false;
        Debug.Log("Attack Finish");
        GameObject[] Bullet = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject A in Bullet)
        {
            Debug.Log("Wait");
            yield return new WaitForSeconds(1f);
        }
        Turn = 1;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("End");
        Check = false;
    }
}
