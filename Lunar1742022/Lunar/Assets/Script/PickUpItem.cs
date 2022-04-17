using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item RefData;
    bool a;
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            Debug.Log("A");
            a = true;

        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.tag == "Player")
        {

            a = false;
        }
    }

    void Ready()
    {
        GameManager.Instance.inventory.current.Add(RefData);
        Destroy(gameObject);
    }

    void Update()
    {
        if (a && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
        {
            Ready();
            Debug.Log("true");
        }
        else if (!a && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)))
        {
            
        }
    }

}
