using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    public int MaxHp;
    int Hp;
    public int MaxElemtGage;
    public int ElemtGage;
    public TextMeshProUGUI HpText;
    string[] Element = new string[] { "Fire", "Water", "Earth", "Wind" };
    public TextMeshProUGUI ElementStatus;
    public static string ElementLADDER;
    bool wait;
    //public GameObject Bullet;
    public float speed;
    public static bool EnemyAttack = false;
    private void Start()
    {
        wait = false;
        ElemtGage = MaxElemtGage;
        Hp = MaxHp;
        string MHP = MaxHp.ToString();
        string HP = Hp.ToString();
        HpText.text = ("Hp " + MHP + "/" + HP);
       
    }


    private void Update()
    {

        if (Hp < 1)
        {
            HpText.text = "Death";
        }
        else
        {
            string MHP = MaxHp.ToString();
            string HP = Hp.ToString();
            HpText.text = ("Hp " + MHP + "/" + HP);
        }

        ElementChange();
        ElementStatus.text = ("ElementGage " + MaxElemtGage + "/" + ElemtGage + ("\n") + "Now - " + ElementLADDER );
        ChangeElemental();
    }

    public void ElementChange()
    {
        switch (ElemtGage)
        {
            case 20:
               ElementLADDER = Element[0].ToString();
                break;
            case 15:
                ElementLADDER = Element[1].ToString();
                break;
            case 12:
                ElementLADDER = Element[2].ToString();
                break;
            case 10:
                ElementLADDER = Element[3].ToString();
                break;
            case 7:
                ElementLADDER = Element[2].ToString();
                break;
            case 5:
                ElementLADDER = Element[1].ToString();
                break;
        }
    }

    public void ChangeElemental()
    {
        if (EnemyAttack)
        {
            if (ElemtGage > 0)
            {
                if (!wait)
                {
                    StartCoroutine(Attack());
                }
            }
        }
    }
    public IEnumerator Attack()
    {
        wait = true;
        if (ElemtGage <= 0)
        {
            ElemtGage = 0;
        }
        else
        {
            if (wait)
            {
          //      Instantiate(Bullet, transform.position, transform.rotation);
                ElemtGage -= 1;
            }
        }
        
        yield return new WaitForSeconds(speed);
        wait = false;
    }

    void GetAttack(int ATTACK)
    {
        if (Hp > 0)
        {
            Hp -= ATTACK;
        }
    }
}
