using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Transform ItemContent;
    public GameObject InventoryItem;

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



     public void ListItem()
     {
        //
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            Debug.Log(item);
            
            obj.transform.Find("item_icon").GetComponent<Image>().sprite = item.iconSprite;
            // var iconSprite = obj.transform.Find("iconSprite").GetComponent<Image>();
            obj.transform.Find("item_name").GetComponent<TextMeshProUGUI>().text = item.itemName;
            // iconSprite.sprite = item.iconSprite; 
        }
     } 
}


