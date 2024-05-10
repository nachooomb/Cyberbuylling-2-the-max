using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class ClickAndMove : MonoBehaviour
{

    public LayerMask whatCanBeClickedOn;

    public AnimatorController ArturoAnim;

    private NavMeshAgent Arturo;

    

    void Start(){
        Arturo = GetComponent<NavMeshAgent>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(1)) {
            Ray movementRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit rayHitInfo;

            if (Physics.Raycast(movementRay,out rayHitInfo, 100, whatCanBeClickedOn)) {
                Arturo.SetDestination (rayHitInfo.point);
                //ArturoAnim.set

            }
        }
    }

}
