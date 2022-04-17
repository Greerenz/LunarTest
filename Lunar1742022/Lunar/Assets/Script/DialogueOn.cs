using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<DialogueThing>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<DialogueThing>().enabled = false;
    }
}
