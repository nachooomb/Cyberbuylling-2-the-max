using UnityEngine;

public class control_arturo : MonoBehaviour
{
    private bool move = true;
    private bool shoot = false;
    private bool exploracion = true;
    private bool combate = false;

    GameObject Arturo;

    GameObject Yerik;

    private yerik YerikScript;
    private ClickAndMove clickAndMove;
    private ClickAndShoot clickAndShoot;
    private item_throw item_Throw;

    private GameObject UIexploracion;
    private GameObject UIcombate;

    
    
    void Start()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        clickAndShoot= Arturo.GetComponent<ClickAndShoot>();
        item_Throw= Arturo.GetComponent<item_throw>();

        UIexploracion = GameObject.Find ("UI exploracion");
        UIcombate = GameObject.Find ("UI combate");

        UIexploracion.SetActive (true);
        UIcombate.SetActive (false);

        Yerik = GameObject.Find ("Yerik_3D");
        YerikScript = Yerik.GetComponent<yerik>();
        YerikScript.enabled = false;

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
        exploracion = !exploracion;

        if (exploracion == true) {
            UIexploracion.SetActive(true);
        }
        if (exploracion == false) {
            UIexploracion.SetActive(false);
        }
    }

    public void ToggleShoot()
    {
        shoot = !shoot;

        if (shoot == true) {
            clickAndShoot.enabled = true;
            item_Throw.enabled = true;
            YerikScript.enabled = true;
        }
        if (shoot == false) {
            clickAndShoot.enabled = false;
            item_Throw.enabled = false;
            YerikScript.enabled = false;
        }
    }

    public void ToggleUIcombate()
    {
        combate = !combate;

        if (combate == true) {
            UIcombate.SetActive(true);
        }
        if (combate == false) {
            UIcombate.SetActive(false);
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
