using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class yerik : MonoBehaviour
{
    GameObject Arturo;

    Combate ArturoCombatStage;

    public int VidaArturo;

    bool Cooldown;

    public int VidaYerik = 100;

    //item_throw _item_Throw;

    int vidaQuitar;

    int _contador = 0;
    int DMG = 0;


    void Start()
    {
        VidaArturo = 104;

        _contador = 0;
        DMG = 0;
        Cooldown = true;

        StartCoroutine(Ataque());
    }

    // Update is called once per frame
    void Update()
    {
        if (VidaArturo > 0 )
        {
            StartCoroutine(Ataque());
        }
        //QuitarVida();
        if (VidaYerik <= 0)
        {
            Debug.Log("Vida = 0 cinematica muerte");
        }


        if (Input.GetKeyDown(KeyCode.H)){
            if (_contador == InventoryManager.Instance.Items.Count){
                    _contador = 0;
                } 
                
                DMG = InventoryManager.Instance.Items[_contador].valueDMG;

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

    IEnumerator Ataque()
    {
        
        if (Cooldown)
        {
            VidaArturo = VidaArturo- 5;
            Cooldown =! Cooldown;
            yield return new WaitForSeconds(6.0f);
            Cooldown =! Cooldown;
        }
        
    }


    void OnCollisionEnter()
    {
        QuitarVida();
        //Debug.Log("colisiona con " + col.gameObject.name);
    }

    void QuitarVida()
    {
        vidaQuitar = DMG;
        
       VidaYerik =VidaYerik-vidaQuitar;

        //Debug.Log("vida " + Vida);
    }
}
