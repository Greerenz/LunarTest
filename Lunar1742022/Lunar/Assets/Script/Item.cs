using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemData")]
public class Item : ScriptableObject
{
    public string id;
    public string displayName;
    public string description;

}
