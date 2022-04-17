using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public Item data;
    public int stackSize; 

    public InventoryItem(Item source)
    {
        data = source;
        AddtoStack();
    }

    public void AddtoStack()
    {
        stackSize++;
    }

    public void RemoveStack()
    {
        stackSize--;
    }
}
