using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class item_throw : MonoBehaviour
{

    public int contador = 0;
    


    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwKey = KeyCode.Mouse0; 
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    void Start()
    {
        readyToThrow = true;    
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H) && contador<=InventoryManager.Instance.Items.Count-1) 
        {
            contador++; 
        } else if (contador == InventoryManager.Instance.Items.Count){
            contador = 0;
        }

        // if (Input.GetKeyDown(KeyCode.G) && contador>= 0)
        // {
        //     contador --;
        // } else if  (contador<0)
        // {
        //     contador = InventoryManager.Instance.Items.Count-1;
        // }

        //Debug.Log("contador " + contador);
        //Debug.Log("largo de la lista " + InventoryManager.Instance.Items.Count);


        objectToThrow = InventoryManager.Instance.Items[contador].Objeto;

        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0) 
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        // instancia el objeto a lanazar
        GameObject proyectile = Instantiate(objectToThrow, attackPoint.position, attackPoint.rotation);

        //get rigid body component
        Rigidbody proyectileRB = proyectile.GetComponent<Rigidbody>();

        //calculate force direction
        Vector3 forceDirection = new Vector3(0, 0, 0);

        Ray aimingRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //
        Vector3 rayDirection = Input.mousePosition - attackPoint.position;

        RaycastHit hit;

        if(Physics.Raycast(aimingRay, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
            Debug.DrawRay(attackPoint.position, hit.point, Color.green);
        } 
        //add force 
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        proyectileRB.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows --;

        //Debug.Log(forceDirection);

        //Debug.DrawRay(attackPoint.position, hit.point, Color.green);


        //implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    } 

}
