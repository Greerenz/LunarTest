using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Amount")==0)
        {
            PlayerPrefs.SetInt("Amount", 0);
            
        }
        Debug.Log("wallet = " + PlayerPrefs.GetInt("Amount"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
