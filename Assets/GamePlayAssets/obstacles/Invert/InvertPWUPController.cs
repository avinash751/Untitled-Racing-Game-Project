using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertPWUPController : MonoBehaviour
{
    PlayerInput playercontrol;
    bool controlinvert;
    public float Time;

    //Andrew's Code
    void OnTriggerEnter2D(Collider2D collision)
    {
        playercontrol = collision.gameObject.GetComponent<PlayerInput>();
        if (collision.gameObject.CompareTag("Player"))
        {
            playercontrol.actions.FindActionMap("Inverted").Enable();
            playercontrol.actions.FindActionMap("Normal").Disable();
            Debug.Log("inverted");
            Invoke(nameof(disableinvertcontrols), Time);
        }
        else
        {
            playercontrol.actions.FindActionMap("Inverted").Disable();
            playercontrol.actions.FindActionMap("Normal").Enable();
        }


    }
    // humaid's code
    void disableinvertcontrols()
    {
        playercontrol.actions.FindActionMap("Inverted").Disable();
        playercontrol.actions.FindActionMap("Normal").Enable();

        Debug.Log("it works");
    }
}
