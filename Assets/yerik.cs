using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class yerik : MonoBehaviour
{
    public int Vida = 100;

    item_throw _item_Throw;

    int vidaQuitar;


    void Start()
    {
        _item_Throw = GameObject.Find("Arturo").GetComponent<item_throw>();
    }

    // Update is called once per frame
    void Update()
    {
        //QuitarVida();
    }

    void OnCollisionEnter(Collision col)
    {
        QuitarVida();
        //Debug.Log("colisiona con " + col.gameObject.name);
    }

    void QuitarVida()
    {
        vidaQuitar = InventoryManager.Instance.Items[_item_Throw.contador].valueDMG;
        
        Vida = Vida-vidaQuitar;

        //Debug.Log("vida " + Vida);
    }
}
