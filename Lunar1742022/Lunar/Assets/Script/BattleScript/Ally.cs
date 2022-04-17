using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ally : MonoBehaviour
{
    public int MaxHp;
    int Hp;
    public TextMeshProUGUI HpText;

    private void Start()
    {
        CheckHPLevel();
        Hp = MaxHp;
        string MHP = MaxHp.ToString();
        string HP = Hp.ToString();
        HpText.text = ("Hp "+ MHP + "/" + HP);
    }

    private void CheckHPLevel()
    {
       int Lv = GameManager.Instance.levelsystem.GetLevel();
        switch (Lv)
        {
            case 0:
                MaxHp = 10;
                break;
            case 1:
                MaxHp = 20;
                break;
        }
    }

    private void Update()
    {
        if(Hp < 1)
        {
            HpText.text = "Death";
        }
        else
        {
            string MHP = MaxHp.ToString();
            string HP = Hp.ToString();
            HpText.text = ("Hp " + MHP + "/" + HP);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetAttack(10);
        }
    }

    public void GetAttack(int ATTACK)
    {
        if(Hp > 0)
        {
            Hp -= ATTACK;
        }
    }


    
}
