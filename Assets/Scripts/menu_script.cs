using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class menu_script : MonoBehaviour
{

    private bool aimState = false;
    Animator _animatorMenu;
    // Start is called before the first frame update
    void Start()
    {
        _animatorMenu = GetComponent<Animator>();
        _animatorMenu.SetBool("Toggle_menu",false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenu()
    {
        
        aimState = !aimState;
            
            _animatorMenu.SetBool("Toggle_menu",aimState);
        
        
        // if (_animatorMenu.GetBool("Toggle_menu") == true && Input.GetMouseButtonDown(0))
        // {
        //     _animatorMenu.SetBool("Toggle_menu",false);
        //     Debug.Log("click");
        // }
    }
}
