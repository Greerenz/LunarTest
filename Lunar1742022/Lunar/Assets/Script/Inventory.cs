using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public int MaxHp;
    int Hp;
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI Name;

    public TextMeshProUGUI Index0, Index1, Index2, Index3, Index4, Index5;

   // private List<Item> itemList;
    public int MaxItem;
    public Inventory current;
    private Dictionary<Item, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory;

    /// <summary>
    /// 
    public Item[] RefItem;
    /// </summary>
    private void Awake()
    {
        current = this;
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<Item, InventoryItem>();
    }

   
    public void Set(InventoryItem item)
    {
        Index0.text = item.data.id;
    }

    public void Add(Item refData)
    {
        if(m_itemDictionary.TryGetValue(refData, out InventoryItem value))
        {
            value.AddtoStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(refData);
            inventory.Add(newItem);
            m_itemDictionary.Add(refData, newItem);
        }
    }

    public void Remove(Item RefData)
    {
        if(m_itemDictionary.TryGetValue(RefData, out InventoryItem value))
        {
            value.RemoveStack();
        }
        if(value.stackSize == 0)
        {
            inventory.Remove(value);
            m_itemDictionary.Remove(RefData);
        }
    
        
    }

    










    private void Start()
    {
        CheckHPLevel();
        Hp = MaxHp;
        string MHP = MaxHp.ToString();
        string HP = Hp.ToString();
        HpText.text = ("Hp " + MHP + "/" + HP);
        Name.text = ("????");
    }

    private void Update()
    {
        if (inventory.Count != 0) 
        {
            Index0.text = inventory[0].data.displayName.ToString();
        } 
        

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
}
