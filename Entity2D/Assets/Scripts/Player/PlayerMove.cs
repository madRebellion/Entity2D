using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    PlayerControls controls;
    Vector2 position;

    float playerMoveSpeed = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        controls.SimpleControls.Interact.performed += _ => Interact();
    }


    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 dir = controls.SimpleControls.Move.ReadValue<Vector2>();

        position = transform.position;
        position += dir * playerMoveSpeed * Time.deltaTime;
        transform.position = position;
    }

    void Interact()
    {
        if (Gamepad.current.buttonSouth.wasPressedThisFrame) { Debug.Log("'A' was pressed."); }

        if (Keyboard.current.eKey.wasPressedThisFrame) { Debug.Log("'E' was pressed."); }
    }



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // OnEnable and OnDisable functions - Mainly used for the new InputSystem                                        //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

}
