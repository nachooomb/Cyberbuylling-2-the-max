using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
//using UnityEngine.TextCore;

public class Click_N_Move : MonoBehaviour
{
    const string IDLE = "idle";
    const string WALK = "walk";

    CustomActions input;

    NavMeshAgent Arturo;
    Animator AnimatorArturo;


    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask whatCanBeClickedOn;

    float lookRotationSpeed = 8f;

    void Awake()
    {
       Arturo = GetComponent<NavMeshAgent>();
       AnimatorArturo = GetComponent<Animator>();

       input = new CustomActions();
       AssingInputs(); 
    }

    void AssingInputs()
    {
        input.Main.going.performed += ctx => ClickToMove();
        //input.Main.Move.performed += ctx => ClickToMove();
    }

    void ClickToMove()
    {
        Debug.Log("click to move");
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100, whatCanBeClickedOn))
        {
            Arturo.destination = hit.point;
            if(clickEffect != null)
            {Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }

        }
    }

    void OnEneable()
    { input.Enable(); }

    void OnDisable()
    { input.Disable(); }

    void Update () 
    {
        FaceTarget();
        SetAnimations();
    }

    void FaceTarget()
    {
        Vector3 direction = (Arturo.destination - transform.position).normalized;
        if(direction != Vector3.zero){
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }

    }

    void SetAnimations()
    {
        if(Arturo.velocity == Vector3.zero)
        {
            AnimatorArturo.Play(IDLE);
        }
        else
        {
            AnimatorArturo.Play(WALK);
        }
    }

}
