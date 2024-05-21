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

    float lookRotationSpeed = 8f;

    [SerializeField] ParticleSystem clickEffect;




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
                if(clickEffect != null)
                {Instantiate(clickEffect, rayHitInfo.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
            }

            FaceTarget();
            
        }


        if(Arturo.remainingDistance>=0.1){
            ArturoAnim.SetBool("walkb", true);
        }else{
            ArturoAnim.SetBool("walkb", false);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (Arturo.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    

    }

}
