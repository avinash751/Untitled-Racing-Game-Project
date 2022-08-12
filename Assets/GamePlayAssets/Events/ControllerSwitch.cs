using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerSwitch : MonoBehaviour
{
    PlayerInput controlswitch;

    //Andrew's Code
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            controlswitch = collision.gameObject.GetComponent<PlayerInput>();
            controlswitch.actions.FindActionMap("Left Side").Disable();
            controlswitch.actions.FindActionMap("Right Side").Enable();
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            controlswitch = collision.gameObject.GetComponent<PlayerInput>();
            controlswitch.actions.FindActionMap("Left Side").Enable();
            controlswitch.actions.FindActionMap("Right Side").Disable();
        }
    }
}
