using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_arturo : MonoBehaviour
{
    private bool move = true;
    private bool shoot = false;
    private bool exploracionUI = true;
    private bool combateUI = false;
    //private bool healthbarUI = false;

    GameObject Arturo;
    GameObject Yerik;

    private yerik yerikScript;
    private ClickAndMove clickAndMove;
    private ClickAndShoot clickAndShoot;
    private item_throw item_Throw;
    private Combate combatStage;
    private Healthbar healthbarArturo;
    private Healthbar healthbarYerik;

    private GameObject UIexploracion;
    private GameObject UIcombate;
    public GameObject UIhealthbarArturo;
    public GameObject UIhealthbarYerik;

    
    
    void Start()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        clickAndShoot= Arturo.GetComponent<ClickAndShoot>();
        item_Throw= Arturo.GetComponent<item_throw>();
        combatStage = Arturo.GetComponent<Combate>();
        healthbarArturo = UIhealthbarArturo.GetComponent<Healthbar>();
        //healthbarArturo = Arturo.GetComponentInChildren<Healthbar>();

        UIexploracion = GameObject.Find ("UI exploracion");
        UIcombate = GameObject.Find ("UI combate");
        //UIhealthbar = GameObject.Find ("Healthbar canvas");

        UIexploracion.SetActive (true);
        UIcombate.SetActive (false);

        Yerik = GameObject.Find ("Yerik_3D");
        yerikScript = Yerik.GetComponent<yerik>();
        healthbarYerik = UIhealthbarYerik.GetComponent<Healthbar>();
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

    public void ToggleUIexploracion()
    {
        exploracionUI = !exploracionUI;

        if (exploracionUI == true) {
            UIexploracion.SetActive(true);
        }
        if (exploracionUI == false) {
            UIexploracion.SetActive(false);
        }
    }

    public void ToggleShoot()
    {
        shoot = !shoot;

        if (shoot == true) {
            clickAndShoot.enabled = true;
            item_Throw.enabled = true;
            yerikScript.enabled = true;
            combatStage.enabled = true;
            healthbarArturo.enabled = true;
            healthbarYerik.enabled = true;
        }
        if (shoot == false) {
            clickAndShoot.enabled = false;
            item_Throw.enabled = false;
            yerikScript.enabled = false;
            combatStage.enabled = false;
            healthbarArturo.enabled = false;
            healthbarYerik.enabled = false;
        }
    }

    public void ToggleUIcombate()
    {
        combateUI = !combateUI;

        if (combateUI == true) {
            UIcombate.SetActive(true);
            UIhealthbarArturo.SetActive(true);
            UIhealthbarYerik.SetActive(true);
        }
        if (combateUI == false) {
            UIcombate.SetActive(false);
            UIhealthbarArturo.SetActive(false);
            UIhealthbarYerik.SetActive(false);
        }
    }

    public void SwitchModes()
    {
       if (Input.GetKeyDown(KeyCode.M)){
            ToggleMove();
            ToggleUIexploracion();
            ToggleShoot();
            ToggleUIcombate();
        } 
        
    }
}
