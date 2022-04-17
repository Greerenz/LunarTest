using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SkillElement : MonoBehaviour
{
    string[] Element = new string[] { "Fire", "Water", "Earth", "Wind" };
    public TextMeshProUGUI Elem0;
    public TextMeshProUGUI Elem1;
    public TextMeshProUGUI Elem2;
    public TextMeshProUGUI Elem3;
    int Select = -1;
    float X;
    float Y;
    bool Wait = false;
    public static bool SelectElem = false;
    public static int ElemPlayer = 0;
    void Start()
    {  
        Elem0.text = Element[0];
        Elem1.text = Element[1];
        Elem2.text = Element[2];
        Elem3.text = Element[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectElem)
        {
            if (Select == -1)
            {
                Debug.Log("SelectMode");
                Select = 0;
            }
        }
        if(Select > -1)
        {
            X = Input.GetAxisRaw("Horizontal");
            Y = Input.GetAxisRaw("Vertical");
            if (X < 0 || X > 0 || Y < 0 || Y > 0)
            {
                if (!Wait)
                {
                    StartCoroutine(WaitSelect());
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                switch (Select)
                {
                    case 0:
                        Debug.Log(Elem0.text);
                        ElemPlayer = 0;
                        Turnbase.Turn = 2;   
                        break;
                    case 1:
                        Debug.Log(Elem1.text);
                        ElemPlayer = 1;
                        Turnbase.Turn = 2;
                        break;
                    case 2:
                        Debug.Log(Elem2.text);
                        ElemPlayer = 2;
                        Turnbase.Turn = 2;
                        break;
                    case 3:
                        Debug.Log(Elem3.text);
                        ElemPlayer = 3;
                        Turnbase.Turn = 2;
                        break;
                }
                Select = -1;
                SelectElem = false;
            }
        }

        ElemSelect();
    }



    IEnumerator WaitSelect()
    {
        Wait = true;
        if (Wait)
        {
            ControlSelect();
        }
        yield return new WaitForSeconds(0.2f);
        Wait = false;
    }
    private void ControlSelect()
    {
        switch (X)
        {
            case -1:
                if(Select == 0)
                {
                    Select = 3;
                }
                else if(Select == 1)
                {
                    Select = 0;
                }
                else if(Select == 2)
                {
                    Select = 1;
                }
                else if(Select == 3)
                {
                    Select = 2;
                }
                break;
            case 1:
                if (Select == 0)
                {
                    Select = 1;
                }
                else if (Select == 1)
                {
                    Select = 2;
                }
                else if (Select == 2)
                {
                    Select = 3;
                }
                else if (Select == 3)
                {
                    Select = 0;
                }
                break;
        }
        switch (Y)
        {
            case -1:
                if (Select == 0)
                {
                    Select = 2;
                }
                else if (Select == 1)
                {
                    Select = 3;
                }
                else if (Select == 2)
                {
                    Select = 0;
                }
                else if (Select == 3)
                {
                    Select = 1;
                }
                break;
            case 1:
                if (Select == 0)
                {
                    Select = 2;
                }
                else if (Select == 1)
                {
                    Select = 3;
                }
                else if (Select == 2)
                {
                    Select = 0;
                }
                else if (Select == 3)
                {
                    Select = 1;
                }
                break;
        }
    }

    public void ElemSelect()
    {
        switch (Select)
        {
            case -1:
                Elem0.fontStyle = FontStyles.UpperCase;
                Elem1.fontStyle = FontStyles.UpperCase;
                Elem2.fontStyle = FontStyles.UpperCase;
                Elem3.fontStyle = FontStyles.UpperCase;
                break;
            case 0:
                Elem0.fontStyle = FontStyles.Underline | FontStyles.UpperCase;
                Elem1.fontStyle = FontStyles.UpperCase;
                Elem2.fontStyle = FontStyles.UpperCase;
                Elem3.fontStyle = FontStyles.UpperCase;
                break;
            case 1:
                Elem0.fontStyle = FontStyles.UpperCase;
                Elem1.fontStyle = FontStyles.Underline | FontStyles.UpperCase;
                Elem2.fontStyle = FontStyles.UpperCase;
                Elem3.fontStyle = FontStyles.UpperCase;
                break;
            case 2:
                Elem0.fontStyle = FontStyles.UpperCase;
                Elem1.fontStyle = FontStyles.UpperCase;
                Elem2.fontStyle = FontStyles.Underline | FontStyles.UpperCase;
                Elem3.fontStyle = FontStyles.UpperCase;
                break;
            case 3:
                Elem0.fontStyle = FontStyles.UpperCase;
                Elem1.fontStyle = FontStyles.UpperCase;
                Elem2.fontStyle = FontStyles.UpperCase;
                Elem3.fontStyle = FontStyles.Underline | FontStyles.UpperCase;
                break;
        }
    }
}
