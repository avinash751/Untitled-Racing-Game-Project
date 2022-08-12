using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertPWUPController : MonoBehaviour
{
    PlayerInput playercontrol;
    bool controlinvert;

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerInput>();
        if (collision.gameObject.CompareTag("Player"))
        {
            playercontrol.actions.FindActionMap("Inverted").Enable();
            playercontrol.actions.FindActionMap("Normal").Disable();
            controlinvert = true;
        }
        else
        {
            playercontrol.actions.FindActionMap("Inverted").Disable();
            playercontrol.actions.FindActionMap("Normal").Enable();
            controlinvert = false;
        }
    }
}
