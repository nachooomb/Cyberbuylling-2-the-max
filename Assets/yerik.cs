using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class yerik : MonoBehaviour
{
    public int Vida = 100;

    item_throw _item_Throw;

    int vidaQuitar;

    int _contador = 0;
    int DMG = 0;


    void Start()
    {
        _item_Throw = GameObject.Find("Arturo").GetComponent<item_throw>();

        _contador = 0;
        DMG = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //_contador = _item_Throw.contador;
        //Debug.Log("vida " + Vida);
        

        //QuitarVida();
        if (Vida <= 0)
        {
            Debug.Log("Vida = 0 cinematica muerte");
        }


        if (Input.GetKeyDown(KeyCode.H)){
            if (_contador == InventoryManager.Instance.Items.Count){
                    _contador = 0;
                } 
                
                DMG = InventoryManager.Instance.Items[_contador].valueDMG;

                Debug.Log("DMG " + DMG);
                Debug.Log("DMG " + DMG);
                Debug.Log("contadopr yerik " + _contador);

                if(_contador<=InventoryManager.Instance.Items.Count-1) 
                {
                    //Debug.Log("contador" + contador);
                    //Debug.Log("lista" + InventoryManager.Instance.Items.Count);
                    _contador++; 
                }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        QuitarVida();
        //Debug.Log("colisiona con " + col.gameObject.name);
    }

    void QuitarVida()
    {
        vidaQuitar = DMG;
        
        Vida = Vida-vidaQuitar;

        //Debug.Log("vida " + Vida);
    }
}
