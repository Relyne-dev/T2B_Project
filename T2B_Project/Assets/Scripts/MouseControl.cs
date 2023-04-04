using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControl : MonoBehaviour
{
    Vector2 mousePos;
    HandControls inputAction;
    
    
    void Awake()
    {
        
        inputAction = new HandControls();



    }

    private void OnEnable()
    {
        inputAction.MouseControls.Enable();
    }

    private void OnDisable()
    {
        inputAction.MouseControls.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();

        
    }
}
