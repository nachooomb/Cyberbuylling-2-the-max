using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemPickUp : MonoBehaviour
{
    public item Item;

    public GameObject Arturo;
    private ClickAndMove clickAndMove;


    void Start ()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
    }

    void PickUp()
    {
        InventoryManager.Instance.AddItem(Item);
        Destroy(gameObject);
        
    }

    private void OnMouseDown()
    {
        clickAndMove.GoDestination(transform.position);
        //Debug.Log( "hola");
        PickUp();
    }
//corrutina
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         PickUp();
    //     }
    // }
}
