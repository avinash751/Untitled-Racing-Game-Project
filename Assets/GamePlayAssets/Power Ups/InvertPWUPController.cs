using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertController : MonoBehaviour
{
    PlayerInput playercontrol;

    void OnTriggerEnter2D(Collider2D collision)
    {
        playercontrol = collision.gameObject.GetComponent<PlayerInput>();
        if (collision.gameObject.CompareTag("Player"))
        {
            playercontrol.actions.FindActionMap("Inverted").Enable();
            playercontrol.actions.FindActionMap("Normal").Disable();
        }
        else
        {
            playercontrol.actions.FindActionMap("Inverted").Disable();
            playercontrol.actions.FindActionMap("Normal").Enable();
        }
    }
}
