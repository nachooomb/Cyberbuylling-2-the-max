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

    private DialogueTrigger dialogueTrigger;

    bool HePinchao = false;


    void Start ()
    {
        Arturo = GameObject.Find ("Arturo");
        clickAndMove = Arturo.GetComponent<ClickAndMove>();
        ArturoNavMesh = Arturo.GetComponent<NavMeshAgent>();
        ArturoAnim = Arturo.GetComponent<Animator>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void Update (){
        //Debug.Log(clickAndMove.distanciaObjeto);
        if(HePinchao == false)  return;

        if(clickAndMove.distanciaObjeto == 0){ return;}


                if(clickAndMove.distanciaObjeto <= 0.1f){
                    PickUp();
                    //yield return null;
                }
            //Debug.Log(clickAndMove.distanciaObjeto);
            
            

    }

    void PickUp()
    {
        InventoryManager.Instance.AddItem(Item);
        Destroy(gameObject);
        
    }

    private void OnMouseDown()
    {
        GoDestinationPickUP(transform.position);

        HePinchao = true;

        //StartCoroutine(ArturoFF());
        
        // if(ArturoNavMesh.remainingDistance>=0.1){
        //     //ArturoAnim.SetBool("walkb", true);
        //     Debug.Log("ando");
        // }else if (ArturoNavMesh.remainingDistance<0.1){
        //     ArturoAnim.SetBool("walkb", false);
        //     dialogueTrigger.TriggerDialogue();
        //     PickUp();
        //     Debug.Log("dejo de andar y pillo el objeto");
        // }
        //Debug.Log( "hola");
    }
//corrutina
    //InventoryManager.cs.metaIEnumerator ArturoFF()
    //{
        // for(;;){
        //     if(clickAndMove.distanciaObjeto != 0){
        //         if(clickAndMove.distanciaObjeto <= 0.5f){
        //             PickUp();
        //             yield return null;
        //         }
        //     Debug.Log(clickAndMove.distanciaObjeto);
            
        //     }
        // }
        

        // yield return new WaitForSeconds(1f);
        // Debug.Log(clickAndMove.distanciaObjeto);
        // while(clickAndMove.distanciaObjeto<0.1)
        // {
        //     yield return null;
        // }

        // PickUp();
        

    //}

     public void GoDestinationPickUP(Vector3 destinationPoint) 
    {
        ArturoNavMesh.SetDestination(destinationPoint);
        //FaceTarget();

        if(ArturoNavMesh.remainingDistance>=0.1){
            //ArturoAnim.SetBool("walkb", true);
        }else{
            //ArturoAnim.SetBool("walkb", false);
            //PickUp();
        }
    }

}
