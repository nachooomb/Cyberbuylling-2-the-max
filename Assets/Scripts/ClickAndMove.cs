using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class ClickAndMove : MonoBehaviour
{

    public LayerMask whatCanBeClickedOn;

    public Animator ArturoAnim;

    private NavMeshAgent Arturo;



    void Start()
    {
        Arturo = GetComponent<NavMeshAgent>();
        ArturoAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray movementRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHitInfo;

            if (Physics.Raycast(movementRay, out rayHitInfo, 100, whatCanBeClickedOn))
            {
                Arturo.SetDestination(rayHitInfo.point);
            }
        }


        if(Arturo.remainingDistance>=0.1){
            ArturoAnim.SetBool("walkb", true);
        }else{
            ArturoAnim.SetBool("walkb", false);
        }

    }

}
