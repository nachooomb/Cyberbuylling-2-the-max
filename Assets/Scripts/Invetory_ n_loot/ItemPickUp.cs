using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ItemPickUp : MonoBehaviour
{
    public item Item;

    public GameObject Arturo;

    private NavMeshAgent ArturoNavMesh;

    public Animator ArturoAnim;

    private ClickAndMove clickAndMove;


    void Start ()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        ArturoNavMesh = Arturo.GetComponent<NavMeshAgent>();
        ArturoAnim = Arturo.GetComponent<Animator>();
    }

    void PickUp()
    {
        InventoryManager.Instance.AddItem(Item);
        Destroy(gameObject);
        
    }

    private void OnMouseDown()
    {
        clickAndMove.GoDestination(transform.position);
        if(ArturoNavMesh.remainingDistance>=0.1){
            ArturoAnim.SetBool("walkb", true);
        }else if (ArturoNavMesh.remainingDistance<0.000001){
            ArturoAnim.SetBool("walkb", false);
            PickUp();
            Debug.Log("dejo de andar y pillo el objeto");
        }
        //Debug.Log( "hola");
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
