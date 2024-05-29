using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class control_arturo : MonoBehaviour
{
    private bool move = true;
    private bool shoot = false;

    GameObject Arturo;
    private ClickAndMove clickAndMove;
    private ClickAndShoot clickAndShoot;
    private item_throw item_Throw;

    
    
    void Start()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        clickAndShoot= Arturo.GetComponent<ClickAndShoot>();
        item_Throw= Arturo.GetComponent<item_throw>();

    }

    // Update is called once per frame
    void Update()
    {
        //activar y desactivar el movimiento
        //SwitchModes();
        
    }

    public void ToggleMove()
    {
        move = !move;

        if (move == true) {
            clickAndMove.enabled = true;
        }
        if (move == false) {
            clickAndMove.enabled = false;
        }
    }

    public void ToggleShoot()
    {
        shoot = !shoot;

        if (shoot == true) {
            clickAndShoot.enabled = true;
            item_Throw.enabled = true;
        }
        if (shoot == false) {
            clickAndShoot.enabled = false;
            item_Throw.enabled = false;
        }
    }

    public void SwitchModes()
    {
       if (Input.GetKeyDown(KeyCode.M)){
            ToggleMove();
            ToggleShoot();
        } 
        
    }
}
