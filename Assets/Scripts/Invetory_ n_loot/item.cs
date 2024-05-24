using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class item : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public int valueDMG;
    public Sprite iconSprite;
    public string itemType;

}
