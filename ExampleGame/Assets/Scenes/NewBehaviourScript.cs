using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject G;
    public Rigidbody2D b;
    void Start()
    {
        b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        G.transform.Translate(0, 0, 0);
    }
}
