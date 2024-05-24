using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<item> Items = new List<item>();

    private void Awake()
    {
        Instance = this;
    }
     public void AddItem(item item)
     {
            Items.Add(item);
     } 

     public void RemoveItem(item item)
     {
            Items.Remove(item);
     } 
}


