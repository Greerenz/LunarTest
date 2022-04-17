using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueThing : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject continueIcon;
    public string[] lines;
     float textSpeed = 0.05f;
    public GameObject Box;
    private int index;
    private bool a = false;
    private bool b = false;


    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
            a = true;
            b = true;
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
           
            a = false;
            b = false;
        }
    }

    
    void Ready()
    {
        GameManager.Instance.dialogue.textComponent.text = string.Empty;
        StartDialogue();
    }



    // Update is called once per frame
    void Update()
    {
        if (b)
        {
            if (a && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
            {
                Ready();
            }
            else if (!a && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
            {

                if (GameManager.Instance.dialogue.textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    GameManager.Instance.dialogue.textComponent.text = lines[index];
                    GameManager.Instance.dialogue.continueIcon.gameObject.SetActive(true);
                }
            }
        }
       
    }

    void StartDialogue()
    {
        PlayerMovement.move = false;      
        index = 0;
        StartCoroutine(Typeline());
        GameManager.Instance.dialogue.Box.gameObject.SetActive(true);
        a = false;
    }

    IEnumerator Typeline()
    {
        GameManager.Instance.dialogue.continueIcon.gameObject.SetActive(false);
        bool ColorTag = false;
        foreach(char c in lines[index].ToCharArray())
        {    
            if (c == '<' || ColorTag)
            {
                ColorTag = true;
                GameManager.Instance.dialogue.textComponent.text += c;
                if (c == '>')
                {
                    ColorTag = false;
                }
            }
            else
            {
                GameManager.Instance.dialogue.textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
       
        }
        GameManager.Instance.dialogue.continueIcon.gameObject.SetActive(true);

    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            GameManager.Instance.dialogue.textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            GameManager.Instance.dialogue.Box.gameObject.SetActive(false);
            PlayerMovement.move = true;
        }
    }
}
